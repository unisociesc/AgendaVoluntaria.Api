using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Services.Core;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;

namespace AgendaVoluntaria.Api.Services
{
    public class VolunteerShiftService : CoreCrudService<VolunteerShift, IVolunteerShiftRepository>, IVolunteerShiftService
    {
        public VolunteerShiftService(INotifier notifier, IVolunteerShiftRepository repository) : base(notifier, repository) { }
    }
}