using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Services.Interfaces
{
    public interface IShiftService : ICoreCrudService<Shift>
    {
        Task<IList<ShiftViewModel>> GetAllWithTotalVolunteersAsync();

        Task<IList<ShiftViewModel>> GetAllByNextDays(int days);
    }
}