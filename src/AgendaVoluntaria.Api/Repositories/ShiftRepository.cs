using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Core;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;

namespace AgendaVoluntaria.Api.Repositories
{
    public class ShiftRepository : CoreRepository<Shift>,IShiftRepository
    {   
        private readonly IVolunteerShiftRepository _volunteerShiftRepository;
        public ShiftRepository(Context context, INotifier notifier, IVolunteerShiftRepository volunteerShiftRepository) : base( context, notifier)
        {
            _volunteerShiftRepository = volunteerShiftRepository;
        }

        public int GetVolunteersCountById(Guid id)
        {
            return _volunteerShiftRepository.GetVolunteersCount(id);
        }
    }
}