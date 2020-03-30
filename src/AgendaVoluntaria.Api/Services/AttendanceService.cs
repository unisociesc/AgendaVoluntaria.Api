using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Services.Core;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;

namespace AgendaVoluntaria.Api.Services
{
    public class AttendanceService : CoreCrudService<Attendance, IAttendanceRepository>, IAttendanceService
    {
        public AttendanceService(INotifier notifier, IAttendanceRepository repository) : base(notifier, repository) { }
    }
}