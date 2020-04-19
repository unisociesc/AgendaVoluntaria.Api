using AgendaVoluntaria.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Repositories.Interfaces
{
    public interface IVolunteerRepository : ICoreRepository<Volunteer>
    {
        Task<IList<Shift>> GetShiftsByVolunteerId(Guid volunteerId);

        public Task<Volunteer> GetVolunteerByUserId(Guid userId);

        public Task<IList<Volunteer>> GetAllVolunteersNeedPsycholistAsync();
    }
}