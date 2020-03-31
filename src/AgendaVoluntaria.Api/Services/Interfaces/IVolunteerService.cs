using AgendaVoluntaria.Api.Models;
using System;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Services.Interfaces
{
    public interface IVolunteerService : ICoreCrudService<Volunteer>
    {
        Task GetShiftsByVolunteerId(Guid idUser);
    }
}