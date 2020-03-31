using AgendaVoluntaria.Api.Controllers.Core;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using AgendaVoluntaria.Api.ViewModel;
using AgendaVoluntaria.Api.Views;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Controllers
{
    public class ShiftsController : CoreCrudController<IShiftService,ShiftRequest,ShiftResponse,Shift>
    {
        private readonly IMapper _mapper;
        private readonly IShiftService _service;

        public ShiftsController(INotifier notifier, IMapper mapper, IShiftService service) : base(notifier, mapper, service) {
            _mapper = mapper;
            _service = service;
        }

        public override async Task<ActionResult<List<ShiftResponse>>> GetAllAsync()
        {

            IList<ShiftResponse> shiftResponse = _mapper.Map<IList<ShiftResponse>>(await _service.GetAllWithTotalVolunteersAsync());

            return CustomResponse("Registros Encontrados", shiftResponse);
        }
    }
}