using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Core;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Repositories
{
    public class AttendanceRepository : CoreRepository<Attendance>,IAttendanceRepository
    {
        public AttendanceRepository(Context context, INotifier notifier) : base( context, notifier) {}

        public override async Task<int> CreateAsync(Attendance entity)
        {
            var beginTime = _context.UserShifts
                .Where(x => x.IdShift == entity.IdShift)
                .Where(x => x.IdUser == entity.IdUser)
                .Select(x => x.Shift.Begin)
                .FirstOrDefault();

            if (DateTime.Now < beginTime.AddMinutes(-15) || DateTime.Now > beginTime.AddMinutes(15) )
            {
                _notifier.Add("Não é possivel fazer o check-in com mais de 15 min de diferença");
                return -1;
            }

            return await base.CreateAsync(entity);
        }
    }
}