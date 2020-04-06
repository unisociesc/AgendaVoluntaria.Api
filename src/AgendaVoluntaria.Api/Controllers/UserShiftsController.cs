using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgendaVoluntaria.Api.Controllers.Core;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Services;
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
        private readonly IUserShiftService _service;
        private readonly IMapper _mapper;
        
        public UserShiftsController(INotifier notifier, IMapper mapper, IUserShiftService service) : base(notifier, mapper, service)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPut("{id:guid}")]
        public override async Task<ActionResult<UserShiftResponse>> Put([FromRoute]Guid id, [FromBody] UserShiftRequest request)
        {
            return await Task.Run(() => StatusCode(405));
        }

        [HttpGet("user")]
        public async Task<ActionResult<UserShiftResponse>> GetShiftsByUser()
        {
            var IdUser = Guid.Parse(GetClaim("IdUser"));
            var registros = await _service.GetUserShiftsByUser(IdUser);
            var result = _mapper.Map<List<UserShiftResponse>>(registros);
            
            return CustomResponse("Registros encontrados!", result);
        }
    }
}