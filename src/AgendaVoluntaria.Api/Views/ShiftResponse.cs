using AgendaVoluntaria.Api.Views.Core;
using System;

namespace AgendaVoluntaria.Api.Views
{
    public class ShiftResponse : BaseResponse
    {
        public DateTime Begin { get; set; }

        public DateTime End { get; set; }

        public int MaxVolunteer { get; set; }

        public int TotalVolunteers { get; set; }
    }
}