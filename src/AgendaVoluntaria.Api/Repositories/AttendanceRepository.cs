using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Core;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Repositories
{
    public class AttendanceRepository : CoreRepository<Attendance>,IAttendanceRepository
    {
        public AttendanceRepository(Context context, INotifier notifier) : base( context, notifier) {}

    }
}