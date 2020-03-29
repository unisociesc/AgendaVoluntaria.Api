using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Models.Interfaces;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Services.Core;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils;
using AgendaVoluntaria.Api.Utils.Interfaces;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Services
{
    public class UserService : CoreCrudService<User, IUserRepository>, IUserService
    {
        public UserService(INotifier notifier, IUserRepository userRepository) : base(notifier, userRepository) { }

        public override Task<int> CreateAsync(User user)
        {
            user.Password = SecurityUtils.EncryptPassword(user.Password);
            return base.CreateAsync(user);
        }

    }
}
