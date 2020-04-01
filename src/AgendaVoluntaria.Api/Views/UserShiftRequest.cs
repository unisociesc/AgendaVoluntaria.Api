using AgendaVoluntaria.Api.Views.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaVoluntaria.Api.Views
{
    public class UserShiftRequest : BaseRequest
    {
        [Required(ErrorMessage = "Informar a identificação do usuário")]
        public Guid IdUser { get; set; }

        [Required(ErrorMessage = "Informar a identificação do turno")]
        public Guid IdShift { get; set; }
    }
}