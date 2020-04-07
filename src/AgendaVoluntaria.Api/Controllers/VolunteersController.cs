using System;
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