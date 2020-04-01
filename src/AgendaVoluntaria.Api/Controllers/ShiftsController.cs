using AgendaVoluntaria.Api.Controllers.Core;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using AgendaVoluntaria.Api.Views;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Controllers
{
    public class ShiftsController : CoreCrudController<IShiftService, ShiftRequest, ShiftResponse, Shift>
    {
        private readonly IMapper _mapper;
        private readonly IShiftService _service;

        public ShiftsController(INotifier notifier, IMapper mapper, IShiftService service) : base(notifier, mapper, service)
        {
            _mapper = mapper;
            _service = service;
        }

        public override async Task<ActionResult<List<ShiftResponse>>> GetAllAsync()
        {

            IList<ShiftResponse> shiftResponse = _mapper.Map<IList<ShiftResponse>>(await _service.GetAllWithTotalVolunteersAsync());

            return CustomResponse("Registros Encontrados", shiftResponse);
        }

        /// <summary> 
        /// Obtem os turnos dos proximos X dias
        /// </summary>
        [HttpGet("{days:int}")]
        public async Task<ActionResult<List<ShiftResponse>>> GetAllByNextDays([FromRoute] int days = 15)
        {
            var shifts = _mapper.Map<IList<ShiftResponse>>(await _service.GetAllByNextDays(days));

            var shiftsFormated = new List<object>();

            foreach (var item in shifts)
            {
                shiftsFormated.Add(new
                {
                    item.Id,
                    item.MaxVolunteer,
                    item.TotalVolunteers,
                    date = item.Begin.ToString("dd-MM-yyyy"),
                    hours = new
                    {
                        Begin = item.Begin.ToString("HH:mm"),
                        End = item.End.ToString("HH:mm")
                    }
                });
            }


            return CustomResponse("Registros Encontrados", shiftsFormated);
        }
    }
}