using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Core;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using AgendaVoluntaria.Api.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Repositories
{
    public class ShiftRepository : CoreRepository<Shift>, IShiftRepository
    {
        public ShiftRepository(Context context, INotifier notifier) : base(context, notifier) { }

        public async Task<IList<ShiftViewlModel>> GetAllByNextDays(int days)
        {
            DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            return await _context.Shifts
                .Where(x => x.Begin >= dateTime && x.Begin < dateTime.AddDays(days))
                .Select(x => new ShiftViewlModel
                {
                    Id = x.Id,
                    Begin = x.Begin,
                    End = x.End,
                    MaxVolunteer = x.MaxVolunteer,
                    CreateAt = x.CreateAt,
                    UpdateAt = x.UpdateAt
                })
                .OrderBy(x => x.Begin)
                .ToListAsync();
        }

        public async Task<IList<ShiftViewlModel>> GetAllWithTotalVolunteersAsync()
        {
            var shifts = await _context.Shifts
                .Select(x => new ShiftViewlModel
                {
                    Id = x.Id,
                    Begin = x.Begin,
                    End = x.End,
                    MaxVolunteer = x.MaxVolunteer,
                    CreateAt = x.CreateAt,
                    UpdateAt = x.UpdateAt
                })
                .OrderBy(x => x.Begin)
                .ToListAsync();

            var volunteerShiftsList = await _context.UserShifts.ToListAsync();
            foreach (var shift in shifts)
            {
                shift.TotalVolunteer = volunteerShiftsList.Where(x => x.IdShift == shift.Id).Count();
            }
            return shifts;
        }
    }
}