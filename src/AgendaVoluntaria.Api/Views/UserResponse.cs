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
        public int CPF { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
    }
}
