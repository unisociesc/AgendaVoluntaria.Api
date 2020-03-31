using System;
using System.Threading.Tasks;
using AgendaVoluntaria.Api.Models;

namespace AgendaVoluntaria.Api.Repositories.Interfaces
{
    public interface IVolunteerShiftRepository : ICoreRepository<VolunteerShift>
    {
        int GetVolunteersCount(Guid id);
    }
}