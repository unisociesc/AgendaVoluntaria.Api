using AgendaVoluntaria.Api.Views.Core;
using System;

namespace AgendaVoluntaria.Api.Views
{
    public class AttendanceResponse : BaseResponse
    {
        public Guid IdVolunteer { get; set; }

        public Guid IdShift { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime Begin { get; set; }

        public DateTime End { get; set; }
    }
}