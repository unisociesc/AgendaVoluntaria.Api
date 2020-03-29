using AgendaVoluntaria.Api.Controllers.Core;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using AgendaVoluntaria.Api.Views;
using AutoMapper;

namespace AgendaVoluntaria.Api.Controllers
{
    public class AttendancesController : CoreCrudController<IAttendanceService,AttendanceRequest,AttendanceResponse,Attendance>
    {
        public AttendancesController(INotifier notifier, IMapper mapper, IAttendanceService service) : base(notifier, mapper, service) {}
    }
}