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
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EmailController : CoreController
    {
        private readonly INotifier _notifier;
        private readonly IUserShiftService _userShiftService;
        
        public EmailController(INotifier notifier, IUserShiftService userShiftService) : base(notifier)
        {
            _notifier = notifier;
            _userShiftService = userShiftService;
        }

        [HttpGet("SendNextDayScheduleForCoordinators")]
        [AllowAnonymous]
        
        public async Task<IActionResult> SendAsync()
        {
            await _userShiftService.SendNextDayScheduleForCoordinators();
            return CustomResponse("Email enviado!");
        }

    }
}