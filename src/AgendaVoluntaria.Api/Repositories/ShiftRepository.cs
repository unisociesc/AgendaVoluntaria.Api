using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Core;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using AgendaVoluntaria.Api.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace AgendaVoluntaria.Api.Repositories
{
    public class ShiftRepository : CoreRepository<Shift>,IShiftRepository
    {   
        private readonly IVolunteerShiftRepository _volunteerShiftRepository;
        public ShiftRepository(Context context, INotifier notifier, IVolunteerShiftRepository volunteerShiftRepository) : base( context, notifier)
        {
            _volunteerShiftRepository = volunteerShiftRepository;
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
                .ToListAsync();

            var volunteerShiftsList = await _context.UserShifts.ToListAsync();
            foreach (var shift in shifts)
            {
                shift.TotalVolunteer = volunteerShiftsList.Where(x => x.IdShift == shift.Id).Count();
            }

                

            return shifts;

            
        }

        public override Task<Shift> GetByIdAsync(Guid id)
        {
            return base.GetByIdAsync(id);
        }

        public int GetVolunteersCountById(Guid id)
        {
            return _volunteerShiftRepository.GetVolunteersCount(id);
        }
    }
}