using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Core;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using AgendaVoluntaria.Api.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Repositories
{
    public class ShiftRepository : CoreRepository<Shift>, IShiftRepository
    {
        public ShiftRepository(Context context, INotifier notifier) : base(context, notifier) { }

        public async Task<IList<ShiftViewModel>> GetAllByNextDays(int days)
        {
            DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            
            var list = await  _context.Shifts
                .Include(x => x.UserShifts)
                    .ThenInclude(x => x.User)
                .Where(x => x.Begin >= dateTime && x.Begin < dateTime.AddDays(days))
                .Select(x => new ShiftViewModel
                    {
                        Id = x.Id,
                        Begin = x.Begin,
                        End = x.End,
                        MaxVolunteer = x.MaxVolunteer,
                        TotalVolunteers = x.UserShifts.Count(),
                        CreateAt = x.CreateAt,
                        UpdateAt = x.UpdateAt,
                        Users = x.UserShifts.Select(x => x.User).ToList()
                    })
                .OrderBy(x => x.Begin)
                .ToListAsync();

                return list;
                
        }

        public async Task<IList<ShiftViewModel>> GetAllWithTotalVolunteersAsync()
        {
            var shifts = await _context.Shifts
                .Include(x => x.UserShifts)
                    .ThenInclude(x => x.User)
                .Select(x => new ShiftViewModel
                {
                    Id = x.Id,
                    Begin = x.Begin,
                    End = x.End,
                    MaxVolunteer = x.MaxVolunteer,
                    TotalVolunteers = x.UserShifts.Count(),
                    CreateAt = x.CreateAt,
                    UpdateAt = x.UpdateAt,
                    Users = x.UserShifts.Select(x => x.User).ToList()
                })
                .OrderBy(x => x.Begin)
                .ToListAsync();

            return shifts;
        }
    }
}