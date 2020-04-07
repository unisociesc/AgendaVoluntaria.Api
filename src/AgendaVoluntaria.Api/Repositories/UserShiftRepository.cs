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
    public class UserShiftRepository : CoreRepository<UserShift>, IUserShiftRepository
    {
        public UserShiftRepository(Context context, INotifier notifier) : base(context, notifier) { }

        public async Task<IList<Shift>> GetShiftsByUserId(Guid guid)
        {
            return await _context.UserShifts
                .Join(_context.Shifts, UserShift => UserShift.IdShift, Shift => Shift.Id, (UserShift, Shift) => new { UserShift, Shift })
                .Where(x => x.UserShift.IdUser == guid)
                .Select(x => x.Shift)
                .ToListAsync();
        }

        public async Task<List<UserShift>> GetUserShiftsByUser(Guid idUser)
        {
            return await _context.UserShifts.Where(x => x.IdUser == idUser).Include(x => x.Shift).ToListAsync();
        }

        public int GetVolunteersCount(Guid idShift)
        {
            return _context.UserShifts.Where(x => x.IdShift == idShift).Count();
        }

        public async Task<List<ScheduleViewModel>> GetSchedulesOfDay(DateTime date)
        {
            return await _context.UserShifts
                .Include(x => x.Shift)
                .Include(x => x.User)
                    .ThenInclude(x => x.Volunteer)
                .Where(x => x.Shift.Begin >= date && x.Shift.Begin < date.AddDays(1))
                .Select(x => new ScheduleViewModel
                {
                    Begin = x.Shift.Begin,
                    End = x.Shift.End,
                    User = x.User
                })
                .OrderBy(x => x.Begin)
                .ToListAsync();

        }

    }
}