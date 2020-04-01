using AgendaVoluntaria.Api.Controllers.Core;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using AgendaVoluntaria.Api.Views;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace AgendaVoluntaria.Api.Controllers
{
    [Authorize(Roles = "volunteers")]
    public class AttendancesController : CoreCrudController<IAttendanceService, AttendanceRequest, AttendanceResponse, Attendance>
    {
        public AttendancesController(INotifier notifier, IMapper mapper, IAttendanceService service) : base(notifier, mapper, service) { }
    }
}