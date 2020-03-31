using System;
using System.Linq;
using System.Threading.Tasks;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Core;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;

namespace AgendaVoluntaria.Api.Repositories
{
    public class UserShiftRepository : CoreRepository<UserShift>,IVolunteerShiftRepository
    {
        public UserShiftRepository(Context context, INotifier notifier) : base( context, notifier) { }

        public int GetVolunteersCount(Guid idShift)
        {
            return _context.UserShifts.Where(x => x.IdShift == idShift).Count();
        }

    }
}