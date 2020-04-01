using AgendaVoluntaria.Api.Controllers.Core;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using AgendaVoluntaria.Api.Views;
using AutoMapper;

namespace AgendaVoluntaria.Api.Controllers
{
    public class VolunteersController : CoreCrudController<IVolunteerService, VolunteerRequest, VolunteerResponse, Volunteer>
    {
        public VolunteersController(INotifier notifier, IMapper mapper, IVolunteerService service) : base(notifier, mapper, service) { }
    }
}