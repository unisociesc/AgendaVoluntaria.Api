using AgendaVoluntaria.Api.Views.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaVoluntaria.Api.Views
{
    public class VolunteerRequest : BaseRequest
    {
        [Required(ErrorMessage = "Informar o RA do voluntário")]
        public int Ra { get; set; }

        [Required(ErrorMessage = "Informar o curso do voluntário")]
        [StringLength(128, MinimumLength = 1)]
        public string Course { get; set; }

        [Required(ErrorMessage = "Informar se o voluntário necessita de psicólogo")]
        public bool NeedPsico { get; set; }

        [Required(ErrorMessage = "Informar a identificação do usuário")]
        public Guid IdUser { get; set; }
    }
}