using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Services.Core;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Services
{
    public class ShiftService : CoreCrudService<Shift, IShiftRepository>,IShiftService
    {
        public ShiftService(INotifier notifier, IShiftRepository repository) : base(notifier, repository) { }

        public override Task<IList<Shift>> GetAllAsync()
        {
            return base.GetAllAsync();
        }

        public override Task<Shift> GetByIdAsync(Guid id)
        {
            return base.GetByIdAsync(id);
        }
    }
}