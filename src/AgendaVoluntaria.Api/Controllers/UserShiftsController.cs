using System;
using System.Threading.Tasks;
using AgendaVoluntaria.Api.Controllers.Core;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using AgendaVoluntaria.Api.Views;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaVoluntaria.Api.Controllers
{
    [Authorize]
    public class UserShiftsController : CoreCrudController<IUserShiftService, UserShiftRequest, UserShiftResponse, UserShift>
    {
        public UserShiftsController(INotifier notifier, IMapper mapper, IUserShiftService service) : base(notifier, mapper, service) { }

        [HttpPut("{id:guid}")]
        public override async Task<ActionResult<UserShiftResponse>> Put([FromRoute]Guid id, [FromBody] UserShiftRequest request)
        {
            return await Task.Run(() => StatusCode(405));
        }
    }
}