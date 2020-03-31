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

        public override Task<int> CreateAsync(Attendance entity)
        {
            entity.Begin = DateTime.Now;

            return base.CreateAsync(entity);
        }

        public override Task<int> UpdateAsync(Attendance entity)
        {
            return base.UpdateAsync(entity);
        }
    }
}