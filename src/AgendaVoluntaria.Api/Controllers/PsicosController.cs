using AgendaVoluntaria.Api.Controllers.Core;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using AgendaVoluntaria.Api.Views;
using AutoMapper;

namespace AgendaVoluntaria.Api.Controllers
{
    public class PsicosController : CoreCrudController<IPsicoService, PsicoRequest, PsicoResponse, Psico>
    {
        public PsicosController(INotifier notifier, IMapper mapper, IPsicoService service) : base(notifier, mapper, service) { }
    }
}