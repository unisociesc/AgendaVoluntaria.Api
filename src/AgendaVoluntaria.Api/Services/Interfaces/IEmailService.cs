
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Services.Interfaces
{
    public interface IEmailService
    {
        public Task SendAsync(string to, string subject, string message);
    }
}
