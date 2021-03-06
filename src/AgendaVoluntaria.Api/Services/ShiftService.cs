using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Services.Core;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using AgendaVoluntaria.Api.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Services
{
    public class ShiftService : CoreCrudService<Shift, IShiftRepository>, IShiftService
    {
        public ShiftService(INotifier notifier, IShiftRepository repository) : base(notifier, repository) { }

        public async Task<IList<ShiftViewModel>> GetAllByNextDays(int days)
        {
            return await _repository.GetAllByNextDays(days);
        }

        public Task<IList<ShiftViewModel>> GetAllWithTotalVolunteersAsync()
        {
            return _repository.GetAllWithTotalVolunteersAsync();
        }
    }
}