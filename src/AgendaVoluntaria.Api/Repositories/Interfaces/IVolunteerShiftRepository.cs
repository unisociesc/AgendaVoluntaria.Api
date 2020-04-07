using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Repositories.Interfaces
{
    public interface IUserShiftRepository : ICoreRepository<UserShift>
    {
        int GetVolunteersCount(Guid id);

        public Task<List<UserShift>> GetUserShiftsByUser(Guid idUser);

        public Task<IList<Shift>> GetShiftsByUserId(Guid guid);

        public Task<List<ScheduleViewModel>> GetSchedulesOfDay(DateTime date);
    }
}