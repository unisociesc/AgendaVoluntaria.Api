using AgendaVoluntaria.Api.Models;
using System;

namespace AgendaVoluntaria.Api.ViewModel
{
    public class ScheduleViewModel
    {
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public User User { get; set; }
    }
}
