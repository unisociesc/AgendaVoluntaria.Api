using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgendaVoluntaria.Api.Models;

namespace AgendaVoluntaria.Api.Repositories.Interfaces
{
    public interface IShiftRepository : ICoreRepository<Shift>
    {
        int GetVolunteersCountById(Guid id);
    }
}