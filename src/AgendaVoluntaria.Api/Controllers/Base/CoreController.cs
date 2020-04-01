using AgendaVoluntaria.Api.Utils.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;

namespace AgendaVoluntaria.Api.Controllers.Core
{
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    [Route("api/[controller]")]
    public class CoreController : ControllerBase
    {
        private readonly INotifier _notifier;
        public CoreController(INotifier notifier) => _notifier = notifier ?? throw new ArgumentNullException(nameof(notifier));

        protected bool OperationValid() => !_notifier.HaveNotification();

        protected ActionResult CustomResponse(string title, object data = null)
        {
            if (!OperationValid())
            {
                return CustomBadRequest();
            }

            if (data != null)
                return Ok(new
                {
                    title,
                    data
                });
            else
                return Ok(new
                {
                    title
                });

        }
        protected ActionResult CustomCreated(string title, object data)
        {
            if (!OperationValid())
            {
                return CustomBadRequest();
            }
            return Created("", new
            {
                title,
                data
            });

        }

        protected ActionResult CustomBadRequest()
        {
            var messages = _notifier.GetNotifications().Select(x => x.Message).ToList();
            return BadRequest(new
            {
                title = "Deu Ruim!",
                errors = messages
            });
        }
        protected ActionResult CustomBadRequest(ModelStateDictionary modelStateDictionary)
        {
            var errors = modelStateDictionary.Values.SelectMany(e => e.Errors);

            foreach (var erro in errors)
            {
                var mensage = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                _notifier.Add(mensage);
            }
            return CustomBadRequest();
        }

        protected string GetClaim(string type)
        {
            return HttpContext.User.Identities.First().Claims.FirstOrDefault(x => x.Type == type).Value;
        }

    }
}
