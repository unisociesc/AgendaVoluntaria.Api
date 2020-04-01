using AgendaVoluntaria.Api.Models;
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

        public override async Task<int> CreateAsync(User newUser)
        {
            newUser.Password = SecurityUtils.EncryptPassword(newUser.Password);

            var user = _repository.GetByAsync(x => x.Email == newUser.Email);
            if (user == null)
            {
                if (string.IsNullOrWhiteSpace(newUser.Role)) newUser.Role = "volunteers";
                return await base.CreateAsync(newUser);
            }
            _notifier.Add("Já existe um usuario cadastrado com este email");
            return -1;
        }

    }
}
