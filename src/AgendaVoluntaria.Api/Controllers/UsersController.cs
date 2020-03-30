using AgendaVoluntaria.Api.Controllers.Core;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using AgendaVoluntaria.Api.Views;
using AutoMapper;

using Microsoft.AspNetCore.Authorization;

namespace AgendaVoluntaria.Api.Controllers
{
    public class UsersController : CoreCrudController<IUserService, UserRequest ,UserResponse, User>
    {
        public UsersController(INotifier notifier, IMapper mapper, IUserService userService) : base(notifier, mapper, userService) { }
    }
}