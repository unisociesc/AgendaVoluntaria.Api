using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Services.Core;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;

namespace AgendaVoluntaria.Api.Services
{
    public class ShiftService : CoreCrudService<Shift, IShiftRepository>,IShiftService
    {
        public ShiftService(INotifier notifier, IShiftRepository repository) : base(notifier, repository) { }
    }
}