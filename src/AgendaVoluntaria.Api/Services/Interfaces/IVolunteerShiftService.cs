using AgendaVoluntaria.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Services.Interfaces
{
    public interface IUserShiftService : ICoreCrudService<UserShift>
    {
        public Task<List<UserShift>> GetUserShiftsByUser(Guid idUser);
    }
}