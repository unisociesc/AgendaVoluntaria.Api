using System;

namespace AgendaVoluntaria.Api.ViewModel
{
    public class BaseViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
