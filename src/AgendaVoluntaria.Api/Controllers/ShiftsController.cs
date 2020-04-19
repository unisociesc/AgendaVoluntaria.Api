using AgendaVoluntaria.Api.Controllers.Core;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using AgendaVoluntaria.Api.Views;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Controllers
{
    [Authorize]
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

            IList<ShiftResponse> shifts = _mapper.Map<IList<ShiftResponse>>(await _service.GetAllWithTotalVolunteersAsync());
            var shiftsFormated = new List<object>();

            foreach (var item in shifts)
            {
                shiftsFormated.Add(new
                {
                    item.Id,
                    item.MaxVolunteer,
                    item.TotalVolunteers,
                    item.Begin,
                    item.End,
                    item.CreateAt,
                    item.UpdateAt
                });
            }

            return CustomResponse("Registros Encontrados", shiftsFormated);
        }

        /// <summary> 
        /// Obtem os turnos dos proximos X dias
        /// </summary>
        [HttpGet("{days:int}")]
        public async Task<ActionResult<List<ShiftResponse>>> GetAllShiftsByNextDays([FromRoute] int days = 15)
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
                    date = item.Begin,
                    hours = new
                    {
                        Begin = item.Begin.ToString("HH:mm"),
                        End = item.End.ToString("HH:mm")
                    }
                });
            }

            return CustomResponse("Registros Encontrados", shiftsFormated);
        }

        /// <summary> 
        /// Obtem os turnos e voluntários dos proximos X dias
        /// </summary>
        //TODO: adicionar role para coordenador
        [HttpGet("users/{days:int}")]
        public async Task<ActionResult<List<ShiftResponse>>> GetAllShiftUsersByNextDays([FromRoute] int days = 15)
        {
            var shifts = await _service.GetAllByNextDays(days);

            var shiftsFormated = new List<object>();

            foreach (var item in shifts)
            {
                shiftsFormated.Add(new
                {
                    item.Id,
                    item.MaxVolunteer,
                    item.TotalVolunteers,
                    date = item.Begin,
                    hours = new
                        {
                            Begin = item.Begin.ToString("HH:mm"),
                            End = item.End.ToString("HH:mm")
                        },
                    users = item.Users
                        .Select(x => new
                            {
                                x.Id,
                                x.Name,
                                x.CPF,
                                x.Phone,
                                x.Email
                            })
                        .ToList()
                });
            }

            return CustomResponse("Registros Encontrados", shiftsFormated);
        }
    }
}