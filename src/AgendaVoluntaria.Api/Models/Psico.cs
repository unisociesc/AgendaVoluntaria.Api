using AgendaVoluntaria.Api.Models.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaVoluntaria.Api.Models
{
    public class Psico : CoreModel
    {
        public Guid IdUser { get; set; }

        [Required]
        [ForeignKey("IdUser")]
        public virtual User User { get; set; }
    }
}