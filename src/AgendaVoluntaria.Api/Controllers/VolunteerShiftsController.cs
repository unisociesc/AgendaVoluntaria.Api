using AgendaVoluntaria.Api.Controllers.Core;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using AgendaVoluntaria.Api.Views;
using AutoMapper;

namespace AgendaVoluntaria.Api.Controllers
{
    public class VolunteerShiftsController : CoreCrudController<IVolunteerShiftService,VolunteerShiftRequest,VolunteerShiftResponse,VolunteerShift>
    {
        public VolunteerShiftsController(INotifier notifier, IMapper mapper, IVolunteerShiftService service) : base(notifier, mapper, service) {}
    }
}