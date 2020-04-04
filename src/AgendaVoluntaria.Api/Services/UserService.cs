using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Services.Core;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils;
using AgendaVoluntaria.Api.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Services
{
    public class UserService : CoreCrudService<User, IUserRepository>, IUserService
    {
        public UserService(INotifier notifier, IUserRepository userRepository) : base(notifier, userRepository) { }

        public override async Task<int> CreateAsync(User newUser)
        {
            newUser.Password = SecurityUtils.EncryptPassword(newUser.Password);

            var user = await _repository.GetByAsync(x => x.Email == newUser.Email);
            if (user.Any())
            {
                _notifier.Add("Já existe um usuario cadastrado com este email");
                return -1;
            }
            if (string.IsNullOrWhiteSpace(newUser.Role)) newUser.Role = "volunteers";
            return await base.CreateAsync(newUser);
        }

        public override async Task<int> UpdateAsync(User entity)
        {
            var user = await _repository.GetByIdAsync(entity.Id);

            if (string.IsNullOrWhiteSpace(entity.Password) || SecurityUtils.EncryptPassword(entity.Password) == user.Password)
                entity.Password = user.Password;
            else
                entity.Password = SecurityUtils.EncryptPassword(entity.Password);

            return await base.UpdateAsync(entity);
        }
    }
}
