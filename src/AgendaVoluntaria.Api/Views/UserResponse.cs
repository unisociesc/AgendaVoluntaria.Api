using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Views.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgendaVoluntaria.Api.Views
{
    public class UserResponse : BaseResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
