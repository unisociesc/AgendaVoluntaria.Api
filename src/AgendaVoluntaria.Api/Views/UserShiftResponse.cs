using System;
using System.ComponentModel.DataAnnotations;
using AgendaVoluntaria.Api.Views.Core;

namespace AgendaVoluntaria.Api.Views
{
    public class UserShiftResponse : BaseResponse
    {
        public Guid IdUser { get; set; }

        public Guid IdShift { get; set; }
    }
}