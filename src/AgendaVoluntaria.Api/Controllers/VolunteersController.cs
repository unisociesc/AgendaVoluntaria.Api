using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgendaVoluntaria.Api.Controllers.Core;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using AgendaVoluntaria.Api.Views;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgendaVoluntaria.Api.Controllers
{
    public class VolunteersController : CoreCrudController<IVolunteerService, VolunteerRequest, VolunteerResponse, Volunteer>
    {
        private readonly IVolunteerService _service;
        private readonly INotifier _notifier;
        public VolunteersController(INotifier notifier, IMapper mapper, IVolunteerService service) : base(notifier, mapper, service)
        {
            _service = service;
            _notifier = notifier;
        }

        //TODO: adicionar role para psicologo
        [HttpGet("needPsychologist")]
        public async Task<ActionResult<List<VolunteerResponse>>> GetAllNeedPsychologistAsync()
        {
            var volunteers = await _service.GetAllVolunteersNeedPsycholistAsync();

            var volunteersFormated = new List<object>();

            foreach (var item in volunteers)
            {
                volunteersFormated.Add(new
                {
                    item.Id,
                    item.Ra,
                    item.Course,
                    item.IdUser,
                    item.NeedPsico,
                    user = new {
                        name = item.User.Name,
                        cpf = item.User.CPF,
                        phone = item.User.Phone,
                        email = item.User.Email
                    }
                });
            }
            
            return CustomResponse("Registros Encontrados", volunteersFormated);
        }

        [HttpPost("needPsychologist")]
        public async Task<IActionResult> NeedPsychologistAsync()
        {
            Guid userId = Guid.Parse(GetClaim("IdUser"));
            Volunteer volunteer = await _service.GetVolunteerByUserIdAsync(userId);
            
            if (volunteer != null)
            {
                Console.WriteLine(volunteer.Id);
                Console.WriteLine(volunteer.IdUser);
                volunteer.NeedPsico = true;
                await _service.UpdateAsync(volunteer);
            }

            return CustomResponse("Registro Atualizado com Sucesso!");
        }
    }
}