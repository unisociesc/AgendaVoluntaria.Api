using System;
using System.Collections.Generic;
using AgendaVoluntaria.Api.Models;

namespace AgendaVoluntaria.Api.ViewModel
{
    public class ShiftViewModel : BaseViewModel
    {
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public int MaxVolunteer { get; set; }
        public int TotalVolunteers { get; set; }
        public IList<User> Users { get; set; }
    }
}
