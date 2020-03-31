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
            return await _context.Shifts
                .Join(_context.VolunteerShifts, Shifts => Shifts.Id, VolunteerShift => VolunteerShift.IdShift, (Shifts, VolunteerShift) => new { Shifts, VolunteerShift })
                .GroupBy(x => new { x.Shifts.Id })
                .Select(x => new ShiftViewlModel
                {
                    Id = x.Key.Id,
                    Begin = x.Max(x => x.Shifts.Begin),
                    End = x.Max(x => x.Shifts.End),
                    MaxVolunteer = x.Max(x => x.Shifts.MaxVolunteer),
                    TotalVonteer = x.Count()
                })
                .ToListAsync();

            
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