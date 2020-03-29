using System;

namespace AgendaVoluntaria.Api.Views
{
    public class LoginResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
