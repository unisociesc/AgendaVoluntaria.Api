using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Services.Core;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Services
{
    public class AttendanceService : CoreCrudService<Attendance, IAttendanceRepository>, IAttendanceService
    {
        private readonly IUserShiftService userShiftService;

        public AttendanceService(INotifier notifier, IAttendanceRepository repository, IUserShiftService userShiftService) : base(notifier, repository)
        {
            this.userShiftService = userShiftService;
        }

        public async Task<int> SaveCheckIn(Attendance attendance)
        {
            attendance.Begin = DateTime.Now;

            var userShifts = await userShiftService.GetUserShiftsByUser(attendance.IdUser);

            var shift = userShifts.Where(x => x.Shift.Begin.Day == DateTime.Now.Day).FirstOrDefault().Shift;

            if (shift == null)
            {
                _notifier.Add("N�o existem agenda para hoje");
                return -1;
            }

            attendance.IdShift = shift.Id;

            if (DateTime.Now < shift.Begin.AddMinutes(-15) || DateTime.Now > shift.Begin.AddMinutes(15))
            {
                _notifier.Add("N�o � possivel fazer o check-in com mais de 15 min de diferen�a");
                return -1;
            }

            if ((attendance.Latitude >= 26.284406 && attendance.Latitude <= -26.290933) || (attendance.Longitude >= -48.809409 && attendance.Longitude <= -48.817181))
            {
                _notifier.Add("A Sua localiza��o n�o coresponde ao Campus Boa Vista");
                return -1;
            }

            return await base.CreateAsync(attendance);
        }
    }
}