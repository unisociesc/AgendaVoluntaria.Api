using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgendaVoluntaria.Api.Models;

namespace AgendaVoluntaria.Api.Repositories.Interfaces
{
    public interface IUserShiftRepository : ICoreRepository<UserShift>
    {
        int GetVolunteersCount(Guid id);

        public Task<List<UserShift>> GetUserShiftsByUser(Guid idUser);
    }
}