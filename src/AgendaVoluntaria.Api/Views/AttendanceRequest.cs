using AgendaVoluntaria.Api.Views.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaVoluntaria.Api.Views
{
    public class AttendanceRequest : BaseRequest
    {
        [Required(ErrorMessage = "Informar o voluntário que compareceu no turno")]
        public Guid IdVolunteer { get; set; }

        [Required(ErrorMessage = "Informar o turno que o voluntário compareceu")]
        public Guid IdShift { get; set; }

        [Required(ErrorMessage = "Informar a geolocalização do comparecimento (latitude)")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "Informar a geolocalização do comparecimento (longitude)")]
        public double Longitude { get; set; }

        [Required(ErrorMessage = "Informar data e hora de início do comparecimento no turno")]
        public DateTime Begin { get; set; }

        [Required(ErrorMessage = "Informar data e hora de fim do comparecimento no turno")]
        public DateTime End { get; set; }
    }
}