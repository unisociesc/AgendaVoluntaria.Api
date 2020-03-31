using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.ViewModel
{
    public class ShiftViewlModel : BaseViewModel
    {
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public int MaxVolunteer { get; set; }
        public int TotalVonteer { get; set; }
    }
}
