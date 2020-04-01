using AgendaVoluntaria.Api.Views.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaVoluntaria.Api.Views
{
    public class PsicoRequest : BaseRequest
    {
        [Required(ErrorMessage = "Informar a identificação do usuário")]
        public Guid IdUser { get; set; }
    }
}