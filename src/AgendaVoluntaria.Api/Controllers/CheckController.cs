using AgendaVoluntaria.Api.Controllers.Core;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using AgendaVoluntaria.Api.Views;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Controllers
{
    [Authorize]
    public class CheckController : CoreController
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IMapper mapper;

        public CheckController(INotifier notifier, IAttendanceService attendanceService, IMapper mapper) : base(notifier)
        {
            _attendanceService = attendanceService;
            this.mapper = mapper;
        }

        /// <summary>
        /// (attendance.Latitude >= 26.284406 && attendance.Latitude <= -26.290933) || (attendance.Longitude >= -48.809409 && attendance.Longitude <= -48.817181)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("in")]
        [HttpPost]
        public async Task<IActionResult> In(CheckRequest geolocalizacao)
        {
            Attendance attendance = this.mapper.Map<Attendance>(geolocalizacao);
            attendance.IdUser = Guid.Parse(GetClaim("IdUser"));
            await _attendanceService.SaveCheckIn(attendance);
            return CustomResponse("Check-In registrado!");
        }

        [HttpPost]
        [Route("out")]
        public async Task<IActionResult> Out(CheckRequest request)
        {
            Attendance attendance = this.mapper.Map<Attendance>(request);
            attendance.IdUser = Guid.Parse(GetClaim("IdUser"));
            await _attendanceService.SaveCheckOut(attendance);
            return CustomResponse("Check-Out registrado!");
        }
    }
}
