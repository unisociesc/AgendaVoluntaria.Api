using AgendaVoluntaria.Api.Models.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaVoluntaria.Api.Models
{
    public class UserShift : CoreModel
    {
        public Guid IdUser { get; set; }

        [Required]
        [ForeignKey("IdUser")]
        public virtual User User { get; set; }

        public Guid IdShift { get; set; }

        [Required]
        [ForeignKey("IdShift")]
        public virtual Shift Shift { get; set; }
    }
}