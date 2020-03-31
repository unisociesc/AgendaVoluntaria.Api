using AgendaVoluntaria.Api.Controllers.Core;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using AgendaVoluntaria.Api.Views;
using AutoMapper;

namespace AgendaVoluntaria.Api.Controllers
{
    public class UserShiftsController : CoreCrudController<IVolunteerShiftService,UserShiftRequest,UserShiftResponse,UserShift>
    {
        public UserShiftsController(INotifier notifier, IMapper mapper, IVolunteerShiftService service) : base(notifier, mapper, service) {}
    }
}