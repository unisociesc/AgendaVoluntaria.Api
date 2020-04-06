using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Services.Core;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Services
{

    public class UserShiftService : CoreCrudService<UserShift, IUserShiftRepository>, IUserShiftService
    {
        private readonly IShiftService _shiftService;
        private readonly IVolunteerService _volunteerService;
        private readonly IUserService _userService;
        private readonly IEmailService emailService;

        public UserShiftService(INotifier notifier,
                                IShiftService shiftService,
                                IVolunteerService volunteerService,
                                IUserService userService,
                                IUserShiftRepository repository,
                                IEmailService emailService
            ) : base(notifier, repository)
        {
            _shiftService = shiftService;
            _volunteerService = volunteerService;
            _userService = userService;
            this.emailService = emailService;
        }

        public override async Task<int> CreateAsync(UserShift volunteerShift)
        {
            User user = await _userService.GetByIdAsync(volunteerShift.IdUser);

            if (user == null)
                return -1;

            Shift shift = await _shiftService.GetByIdAsync(volunteerShift.IdShift);

            if (shift == null)
                return -1;


            var volunteerShifts = await _repository.GetShiftsByUserId(volunteerShift.IdUser);
            var volunteerShiftsQuerable = volunteerShifts
                .Where(x => x.Begin.AddHours(24) > shift.Begin && x.Begin.AddHours(-24) < shift.Begin);
            if (volunteerShiftsQuerable.Any())
            {
                _notifier.Add("Existe outro turno já atribuido ao voluntario, com intervalo menor de 24 horas");
                return -1;
            }

            int volunteers = _repository.GetVolunteersCount(shift.Id);

            if (volunteers >= shift.MaxVolunteer)
            {
                _notifier.Add("Limite de voluntários excedido para este turno");
                return -1;
            }

            return await base.CreateAsync(volunteerShift);
        }

        public async Task SendNextDayScheduleForCoordinators()
        {

            var schedules = await _repository.GetSchedulesOfDay(DateTime.Today.AddDays(1));
            var shifts = schedules.GroupBy(x => new { x.Begin, x.End }).OrderBy(x => x.Key.Begin).ToList();

            string rowColor = string.Empty;
            string htmlTable = string.Empty;           
            foreach (var shift in shifts)
            {
                rowColor = rowColor.Equals("#F8F8F8") ? "#f1f1f1" : "#F8F8F8";

                htmlTable += $"<tr style='border-collapse:collapse;box-sizing:border-box;-webkit-box-sizing:border-box;-moz-box-sizing:border-box;color: #333333; background: {rowColor};'>";
                htmlTable += $"<td style='padding:8px;Margin:0;box-sizing:border-box;-webkit-box-sizing:border-box;-moz-box-sizing:border-box;text-align:center;border-right:1px solid #F8F8F8;font-size:12px;'>{shift.Key.Begin:HH:mm} as {shift.Key.End:HH:mm}</td>";
                htmlTable += "<td style='padding:8px;Margin:0;box-sizing:border-box;-webkit-box-sizing:border-box;-moz-box-sizing:border-box;text-align:center;border-right:1px solid #F8F8F8;font-size:12px;'>";
                foreach (var volunteer in schedules)
                {
                    if (volunteer.Begin == shift.Key.Begin)
                    {
                        htmlTable += $"{volunteer.User.Name} - {volunteer.User.Phone} <br style='box-sizing:border-box;-webkit-box-sizing:border-box;-moz-box-sizing:border-box;'>";
                    }
                }
                htmlTable += "</td>";
                htmlTable += "</tr>";
            }
            
            string html = string.Empty;

            string path = Directory.GetCurrentDirectory();
            path = Path.GetFullPath("schedules.html");
            using (StreamReader reader = new StreamReader(path))
            {
                html = reader.ReadToEnd();
            }

            html = html.Replace("#DAY#", DateTime.Today.AddDays(1).Day.ToString());
            html = html.Replace("#MONTH#", DateTime.Today.AddDays(1).Month.ToString());
            html = html.Replace("#TABLE-BODY#", htmlTable);
            emailService.SendAsync("ghmeyer0@gmail.com", "Triagem COVID-19 - Escala", html);
            
            return;
            
        }

        public async Task<List<UserShift>> GetUserShiftsByUser(Guid idUser)
        {
            return await _repository.GetUserShiftsByUser(idUser);
        }
    }
}