using System;
using System.ComponentModel.DataAnnotations;
using AgendaVoluntaria.Api.Views.Core;

namespace AgendaVoluntaria.Api.Views
{
    public class PsicoRequest : BaseRequest
    {
        [Required(ErrorMessage = "Informar a identificação do usuário")]
        public Guid IdUser { get; set; }
    }
}