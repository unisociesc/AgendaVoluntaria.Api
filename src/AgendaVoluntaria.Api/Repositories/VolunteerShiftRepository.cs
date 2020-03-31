using System;
using System.Linq;
using System.Threading.Tasks;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Core;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;

namespace AgendaVoluntaria.Api.Repositories
{
    public class VolunteerShiftRepository : CoreRepository<VolunteerShift>,IVolunteerShiftRepository
    {
        public VolunteerShiftRepository(Context context, INotifier notifier) : base( context, notifier) { }

        public int GetVolunteersCount(Guid idShift)
        {
            return _context.VolunteerShifts.Where(x => x.IdShift == idShift).Count();
        }

    }
}