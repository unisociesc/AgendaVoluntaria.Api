using System;

namespace AgendaVoluntaria.Api.ViewModel
{
    public class ShiftViewlModel : BaseViewModel
    {
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public int MaxVolunteer { get; set; }
        public int TotalVolunteers { get; set; }
    }
}
