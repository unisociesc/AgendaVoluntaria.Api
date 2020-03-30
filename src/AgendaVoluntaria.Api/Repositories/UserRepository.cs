using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Models.Interfaces;
using AgendaVoluntaria.Api.Repositories.Core;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Repositories
{
    public class UserRepository : CoreRepository<User>, IUserRepository
    {
        public UserRepository(Context context, INotifier notifier) : base(context, notifier) { }

        public override async Task<int> CreateAsync(User entity)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == entity.Email);
            if (user == null)
            {
                user.Role = "volunteers";
                return await base.CreateAsync(entity);
            }
            _notifier.Add("Já existe um usuario cadastrado com este email");
            return -1;
            
        }
    }
}
