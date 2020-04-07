using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Core;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Repositories
{
    public class VolunteerRepository : CoreRepository<Volunteer>, IVolunteerRepository
    {
        public VolunteerRepository(Context context, INotifier notifier) : base(context, notifier) { }

        public async Task<IList<Shift>> GetShiftsByVolunteerId(Guid volunteerId)
        {
            return await _context.UserShifts
                .Join(_context.Shifts, volunteerShift => volunteerShift.IdShift, shift => shift.Id, (volunteerShift, shift) => new { VolunteerShift = volunteerShift, Shift = shift })
                .Where(x => x.VolunteerShift.IdUser == volunteerId)
                .Select(x => x.Shift)
                .ToListAsync();
        }

        public async Task<Volunteer> GetVolunteerByUserId(Guid userId)
        {
            return await _context.Volunteers.Where(x => x.IdUser == userId)
                .FirstOrDefaultAsync();
        }
    }
}