using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Core;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Repositories
{
    public class UserRepository : CoreRepository<User>, IUserRepository
    {
        public UserRepository(Context context, INotifier notifier) : base(context, notifier) { }
    }
}
