using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Services.Core;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using System;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Services
{
    public class VolunteerService : CoreCrudService<Volunteer, IVolunteerRepository>, IVolunteerService
    {
        public VolunteerService(INotifier notifier, IVolunteerRepository repository) : base(notifier, repository) { }

    }
}