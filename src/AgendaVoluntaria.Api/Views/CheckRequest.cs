using System;

namespace AgendaVoluntaria.Api.Views
{
    public class CheckRequest
    {
        public Guid IdShift { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
