using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Services.Core;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Services
{
    public class VolunteerService : CoreCrudService<Volunteer, IVolunteerRepository>, IVolunteerService
    {
        private readonly IVolunteerRepository _repository;

        public VolunteerService(INotifier notifier, IVolunteerRepository repository) : base(notifier, repository)
        {
            _repository = repository;
        }

        public Task<Volunteer> GetVolunteerByUserIdAsync(Guid userId)
        {
            return _repository.GetVolunteerByUserId(userId);
        }

        public Task<IList<Volunteer>> GetAllVolunteersNeedPsycholistAsync()
        {
            return _repository.GetAllVolunteersNeedPsycholistAsync();
        }
    }
}