using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Services.Interfaces
{
    public interface IShiftService : ICoreCrudService<Shift>
    {
        Task<IList<ShiftViewlModel>> GetAllWithTotalVolunteersAsync();
    }
}