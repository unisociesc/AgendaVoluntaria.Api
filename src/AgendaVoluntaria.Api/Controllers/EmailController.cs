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
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EmailController : CoreController
    {
        private readonly INotifier _notifier;
        private readonly IEmailService _emailService;
        
        public EmailController(INotifier notifier, IEmailService emailService) : base(notifier)
        {
            _notifier = notifier;
            _emailService = emailService;
        }

        [HttpGet]
        public virtual IActionResult SendAsync()
        {
            _emailService.SendAsync("allanrodrigol@gmail.com","Teste","Olá mundo!");
            return CustomResponse("Email enviado!");
        }

    }
}