using AgendaVoluntaria.Api.Views.Core;
using System;

namespace AgendaVoluntaria.Api.Views
{
    public class UserShiftResponse : BaseResponse
    {
        public Guid IdUser { get; set; }

        public Guid IdShift { get; set; }
    }
}