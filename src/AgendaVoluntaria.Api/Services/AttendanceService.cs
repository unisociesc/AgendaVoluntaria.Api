using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Services.Core;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using AgendaVoluntaria.Api.Views;
using System;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Services
{
    public class AttendanceService : CoreCrudService<Attendance, IAttendanceRepository>, IAttendanceService
    {
        public AttendanceService(INotifier notifier, IAttendanceRepository repository ) : base(notifier, repository) { }

        public async Task<int> SaveCheckIn(Attendance attendance)
        {

            // TODO: Pegar horario de
            var beginTime = DateTime.Now;

            if (DateTime.Now < beginTime.AddMinutes(-15) || DateTime.Now > beginTime.AddMinutes(15))
            {
                _notifier.Add("Não é possivel fazer o check-in com mais de 15 min de diferença");
                return -1;
            }

            return await base.CreateAsync(attendance);
        }
    }
}