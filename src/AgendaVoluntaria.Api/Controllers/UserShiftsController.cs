using AgendaVoluntaria.Api.Controllers.Core;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using AgendaVoluntaria.Api.Views;
using AutoMapper;

namespace AgendaVoluntaria.Api.Controllers
{
    public class UserShiftsController : CoreCrudController<IUserShiftService, UserShiftRequest, UserShiftResponse, UserShift>
    {
        public UserShiftsController(INotifier notifier, IMapper mapper, IUserShiftService service) : base(notifier, mapper, service) { }
    }
}