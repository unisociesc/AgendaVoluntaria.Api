using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.ViewModel;

namespace AgendaVoluntaria.Api.Repositories.Interfaces
{
    public interface IShiftRepository : ICoreRepository<Shift>
    {
        Task<IList<ShiftViewlModel>> GetAllWithTotalVolunteersAsync();

        Task<IList<ShiftViewlModel>> GetAllByNextDays(int days);
    }
}