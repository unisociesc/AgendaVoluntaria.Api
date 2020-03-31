using System;
using System.ComponentModel.DataAnnotations;
using AgendaVoluntaria.Api.Views.Core;

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