using System;
using System.ComponentModel.DataAnnotations;
using AgendaVoluntaria.Api.Models.Core;

namespace AgendaVoluntaria.Api.Models
{
    public class Shift : CoreModel
    {
        [Required]
        public DateTime Begin { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public int MaxVolunteer { get; set; }

        public ShiftsDescription Name { get; set; }
    }
}