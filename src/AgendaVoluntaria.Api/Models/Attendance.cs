using AgendaVoluntaria.Api.Models.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaVoluntaria.Api.Models
{
    public class Attendance : CoreModel
    {
        [Required]
        public DateTime Begin { get; set; }

        public DateTime? End { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        public Guid IdUser { get; set; }

        [Required]
        [ForeignKey("IdUser")]
        public User User { get; set; }

        public Guid IdShift { get; set; }

        [Required]
        [ForeignKey("IdShift")]
        public Shift Shift { get; set; }
    }
}