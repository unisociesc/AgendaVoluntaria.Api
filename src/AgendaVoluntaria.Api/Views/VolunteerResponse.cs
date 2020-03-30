using System;
using System.ComponentModel.DataAnnotations;
using AgendaVoluntaria.Api.Views.Core;

namespace AgendaVoluntaria.Api.Views
{
    public class VolunteerResponse : BaseResponse
    {
        public int Ra { get; set; }

        public string Course { get; set; }

        public bool NeedPsico { get; set; }

        public Guid IdUser { get; set; }
    }
}