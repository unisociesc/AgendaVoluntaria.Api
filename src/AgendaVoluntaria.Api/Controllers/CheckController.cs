using AgendaVoluntaria.Api.Controllers.Core;
using AgendaVoluntaria.Api.Utils.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Controllers
{
    public class CheckController : CoreController
    {
        public CheckController(INotifier notifier) : base(notifier)
        {
        }

        [Route("in")]
        [HttpPost]
        public async Task<IActionResult> In ()
        {
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
