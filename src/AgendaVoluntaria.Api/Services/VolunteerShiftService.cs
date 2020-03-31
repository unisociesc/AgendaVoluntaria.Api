using System.Linq;
using System.Threading.Tasks;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Services.Core;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;

namespace AgendaVoluntaria.Api.Services
{

    public class VolunteerShiftService : CoreCrudService<VolunteerShift, IVolunteerShiftRepository>, IVolunteerShiftService
    {
        private readonly IShiftRepository _shiftRepository;
        public VolunteerShiftService(INotifier notifier, IVolunteerShiftRepository repository, IShiftRepository shiftRepository) : base(notifier, repository)
        {
            _shiftRepository = shiftRepository;
        }

        public override async Task<int> CreateAsync(VolunteerShift volunteerShift)
        {
            Shift shift = await _shiftRepository.GetByIdAsync(volunteerShift.IdShift);
            
            var volunteerShifts = await base.GetByAsync(x => x.IdVolunteer == volunteerShift.IdVolunteer);
            
            volunteersShifts.Where(x => x.Begin)

            foreach (var item in volunteerShifts)
            {
                Shift x = await _shiftRepository.GetByIdAsync(item.IdShift);

                if (x.Begin.AddHours(24) < shift.Begin && x.Begin.AddHours(-24) > shift.Begin)
                {
                    
                }
            }

            volunteerShifts.Where(x => x.)

            int volunteers = _shiftRepository.GetVolunteersCountById(volunteerShift.IdShift);
            
            if (shift.MaxVolunteer < volunteers)
            {
                return await base.CreateAsync(volunteerShift);
            }

            _notifier.Add("Limite de voluntários excedido para este turno");

            return -1;
        }
    }
}