using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Services.Core;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;

namespace AgendaVoluntaria.Api.Services
{
    public class PsicoService : CoreCrudService<Psico, IPsicoRepository>, IPsicoService
    {
        public PsicoService(INotifier notifier, IPsicoRepository repository) : base(notifier, repository) { }
    }
}