using AgendaVoluntaria.Api.Models.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgendaVoluntaria.Api.Models
{
    public class User : CoreModel
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [MaxLength(128)]
        public string Email { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 6)]
        public string Password { get; set; }

        [StringLength(11, MinimumLength = 11)]
        public string CPF { get; set; }

        public string Phone { get; set; }

        [Required]
        public string Role { get; set; }

        public Volunteer Volunteer { get; set; }
    }
}
