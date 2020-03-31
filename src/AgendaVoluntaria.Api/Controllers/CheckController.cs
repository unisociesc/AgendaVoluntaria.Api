using AgendaVoluntaria.Api.Controllers.Core;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using AgendaVoluntaria.Api.Views;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Controllers
{
    public class CheckController : CoreController
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IMapper mapper;

        public CheckController(INotifier notifier, IAttendanceService attendanceService, IMapper mapper) : base(notifier)
        {
            _attendanceService = attendanceService;
            this.mapper = mapper;
        }

        [Route("in")]
        [HttpPost]
        public async Task<IActionResult> In(CheckRequest request)
        {
            Attendance attendance = this.mapper.Map<Attendance>(request);
            attendance.IdUser = Guid.Parse(GetClaim("IdUser"));
            await _attendanceService.CreateAsync(attendance);
            return CustomResponse("Check-In registrado!");
        }

        
        [HttpPost]
        [Route("out")]
        public async Task<IActionResult> Out(CheckRequest request)
        {
            Attendance attendance = this.mapper.Map<Attendance>(request);
            attendance.IdUser = Guid.Parse(GetClaim("IdUser"));
            await _attendanceService.UpdateAsync(attendance);
            return CustomResponse("Check-Out registrado!");
        }


    }
}
