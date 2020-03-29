using System;
using System.ComponentModel.DataAnnotations;
using AgendaVoluntaria.Api.Views.Core;

namespace AgendaVoluntaria.Api.Views
{
    public class PsicoResponse : BaseResponse
    {
        public Guid IdUser { get; set; }
    }
}