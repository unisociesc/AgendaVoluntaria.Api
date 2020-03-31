using System.Linq;
using System.Threading.Tasks;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Services.Core;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;

namespace AgendaVoluntaria.Api.Services
{

    public class UserShiftService : CoreCrudService<UserShift, IVolunteerShiftRepository>, IVolunteerShiftService
    {
        private readonly IShiftRepository _shiftRepository;
        private readonly IVolunteerRepository _volunteerRepository;
        private readonly IUserRepository _userRepository;

        public UserShiftService(INotifier notifier, IVolunteerShiftRepository repository, IShiftRepository shiftRepository, IVolunteerRepository volunteerRepository, IUserRepository userRepository) : base(notifier, repository)
        {
            _shiftRepository = shiftRepository;
            _volunteerRepository = volunteerRepository;
            _userRepository = userRepository;
        }

        public override async Task<int> CreateAsync(UserShift volunteerShift)
        {
            User user = await _userRepository.GetByIdAsync(volunteerShift.IdUser);

            if (user == null)
                return -1;

            Shift shift = await _shiftRepository.GetByIdAsync(volunteerShift.IdShift);

            if (shift == null)
                return -1; 

            var volunteerShifts = await _volunteerRepository.GetShiftsByVolunteerId(volunteerShift.IdUser);

            var volunteerShiftsQuerable = volunteerShifts
                .Where(x => x.Begin.AddHours(24) < shift.Begin && x.Begin.AddHours(-24) > shift.Begin);

            if (volunteerShiftsQuerable.Any())
            {
                _notifier.Add("Existe outro turno já atribuido ao voluntario, com intervalo menor de 24 horas");
                return -1;
            }

            int volunteers = _shiftRepository.GetVolunteersCountById(volunteerShift.IdShift);

            if (volunteers >= shift.MaxVolunteer)
            {
                _notifier.Add("Limite de voluntários excedido para este turno");
                return -1;
            }

            return await base.CreateAsync(volunteerShift);
        }
    }
}