using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Services.Core;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Services
{

    public class UserShiftService : CoreCrudService<UserShift, IUserShiftRepository>, IUserShiftService
    {
        private readonly IShiftService _shiftService;
        private readonly IVolunteerService _volunteerService;
        private readonly IUserService _userService;

        public UserShiftService(INotifier notifier,
                                IShiftService shiftService,
                                IVolunteerService volunteerService,
                                IUserService userService,
                                IUserShiftRepository repository) : base(notifier, repository)
        {
            _shiftService = shiftService;
            _volunteerService = volunteerService;
            _userService = userService;
        }

        public override async Task<int> CreateAsync(UserShift volunteerShift)
        {
            User user = await _userService.GetByIdAsync(volunteerShift.IdUser);

            if (user == null)
                return -1;

            Shift shift = await _shiftService.GetByIdAsync(volunteerShift.IdShift);

            if (shift == null)
                return -1;


            var volunteerShifts = await _repository.GetShiftsByUserId(volunteerShift.IdUser);
            var volunteerShiftsQuerable = volunteerShifts
                .Where(x => x.Begin.AddHours(24) > shift.Begin && x.Begin.AddHours(-24) < shift.Begin);
            if (volunteerShiftsQuerable.Any())
            {
                _notifier.Add("Existe outro turno já atribuido ao voluntario, com intervalo menor de 24 horas");
                return -1;
            }

            int volunteers = _repository.GetVolunteersCount(shift.Id);

            if (volunteers >= shift.MaxVolunteer)
            {
                _notifier.Add("Limite de voluntários excedido para este turno");
                return -1;
            }

            return await base.CreateAsync(volunteerShift);
        }

        public async Task<List<UserShift>> GetUserShiftsByUser(Guid idUser)
        {
            return await _repository.GetUserShiftsByUser(idUser);
        }
    }
}