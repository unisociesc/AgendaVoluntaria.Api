using AgendaVoluntaria.Api.Models.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public ICollection<UserShift> UserShifts { get; set; }

    }
}