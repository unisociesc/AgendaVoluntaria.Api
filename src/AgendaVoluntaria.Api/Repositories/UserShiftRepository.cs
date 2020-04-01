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
    public class UserShiftRepository : CoreRepository<UserShift>, IUserShiftRepository
    {
        public UserShiftRepository(Context context, INotifier notifier) : base(context, notifier) { }

        public async Task<List<UserShift>> GetUserShiftsByUser(Guid idUser)
        {
            return await _context.UserShifts.Where(x => x.IdUser == idUser).Include(x => x.Shift).ToListAsync();
        }

        public int GetVolunteersCount(Guid idShift)
        {
            return _context.UserShifts.Where(x => x.IdShift == idShift).Count();
        }

    }
}