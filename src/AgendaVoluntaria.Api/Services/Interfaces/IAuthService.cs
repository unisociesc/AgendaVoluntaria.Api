using AgendaVoluntaria.Api.Views;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest user);
        Task<LoginResponse> Register(UserRequest userResgister);
    }
}
