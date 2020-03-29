using AgendaVoluntaria.Api.Controllers.Core;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using AgendaVoluntaria.Api.Views;
using AutoMapper;

namespace AgendaVoluntaria.Api.Controllers
{
    public class ShiftsController : CoreCrudController<IShiftService,ShiftRequest,ShiftResponse,Shift>
    {
        public ShiftsController(INotifier notifier, IMapper mapper, IShiftService service) : base(notifier, mapper, service) {}
    }
}