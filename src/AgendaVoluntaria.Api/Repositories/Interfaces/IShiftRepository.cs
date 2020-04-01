using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Repositories.Interfaces
{
    public interface IShiftRepository : ICoreRepository<Shift>
    {
        Task<IList<ShiftViewlModel>> GetAllWithTotalVolunteersAsync();

        Task<IList<ShiftViewlModel>> GetAllByNextDays(int days);
    }
}