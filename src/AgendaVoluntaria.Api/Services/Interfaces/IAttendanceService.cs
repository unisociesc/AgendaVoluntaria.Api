using AgendaVoluntaria.Api.Models;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Services.Interfaces
{
    public interface IAttendanceService : ICoreCrudService<Attendance>
    {
        public Task<int> SaveCheckIn(Attendance attendance);

        public Task<int> SaveCheckOut(Attendance attendance);
    }
}