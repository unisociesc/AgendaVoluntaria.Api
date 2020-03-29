using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgendaVoluntaria.Api.Models.Core;

namespace AgendaVoluntaria.Api.Models
{
    public class Psico : CoreModel
    {
        public Guid IdUser { get; set; }
        
        [Required]
        [ForeignKey("IdUser")]
        public User User { get; set; }
    }
}