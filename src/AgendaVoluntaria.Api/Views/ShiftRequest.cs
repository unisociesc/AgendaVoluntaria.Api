using AgendaVoluntaria.Api.Views.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaVoluntaria.Api.Views
{
    public class ShiftRequest : BaseRequest
    {
        [Required(ErrorMessage = "Informar data e hora de início do turno")]
        public DateTime Begin { get; set; }

        [Required(ErrorMessage = "Informar data e hora de fim do turno")]
        public DateTime End { get; set; }

        [Required(ErrorMessage = "Informar o número de voluntários do turno")]
        [Range(1, Int64.MaxValue, ErrorMessage = "O número de voluntários do turno deve ser maior que 0")]
        public int MaxVolunteer { get; set; }
    }
}