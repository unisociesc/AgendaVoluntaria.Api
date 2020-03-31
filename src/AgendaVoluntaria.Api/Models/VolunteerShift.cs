using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgendaVoluntaria.Api.Models.Core;

namespace AgendaVoluntaria.Api.Models
{
    public class VolunteerShift : CoreModel
    {
        public Guid IdVolunteer { get; set; }

        [Required]
        [ForeignKey("IdVolunteer")]
        public Volunteer Volunteer { get; set; }

        public Guid IdShift { get; set; }

        [Required]
        [ForeignKey("IdShift")]
        public Shift Shift { get; set; }
    }
}