using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgendaVoluntaria.Api.Models.Core;

namespace AgendaVoluntaria.Api.Models
{
    public class Attendance : CoreModel
    {
        [Required]
        public DateTime Begin { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

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