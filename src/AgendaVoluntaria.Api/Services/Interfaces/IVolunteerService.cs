using AgendaVoluntaria.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Services.Interfaces
{
    public interface IVolunteerService : ICoreCrudService<Volunteer>
    {
        Task<Volunteer> GetVolunteerByUserIdAsync(Guid userId);
    }
}