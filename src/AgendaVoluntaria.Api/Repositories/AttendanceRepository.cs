using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Core;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;

namespace AgendaVoluntaria.Api.Repositories
{
    public class AttendanceRepository : CoreRepository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(Context context, INotifier notifier) : base(context, notifier) { }

    }
}