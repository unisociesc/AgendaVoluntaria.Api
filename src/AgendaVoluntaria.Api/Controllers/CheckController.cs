using AgendaVoluntaria.Api.Controllers.Core;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Controllers
{
    public class CheckController : CoreController
    {
        private readonly IAttendanceService _attendanceService;

        public CheckController(INotifier notifier, IAttendanceService attendanceService) : base(notifier)
        {
            _attendanceService = attendanceService;
        }

        [Route("in")]
        [HttpPost]
        public async Task<IActionResult> In()
        {
            HttpContext.User.Identities.First().Claims.Select(X => X.Type);
            return Ok();
        }

        
        [HttpPost]
        [Route("out")]
        public async Task<IActionResult> Out()
        {
            return Ok();
        }


    }
}
