using AutoMapper;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Views;
using AgendaVoluntaria.Api.ViewModel;

namespace AgendaVoluntaria.Api.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            

            CreateMap<ShiftRequest, Shift>();
            CreateMap<Shift, ShiftResponse>();

            CreateMap<AttendanceRequest, Attendance>();
            CreateMap<Attendance, AttendanceResponse>();

            CreateMap<PsicoRequest, Psico>();
            CreateMap<Psico, PsicoResponse>();

            CreateMap<UserRequest, User>();
            CreateMap<User, UserResponse>();
            CreateMap<User, LoginResponse>();

            CreateMap<VolunteerRequest, Volunteer>();
            CreateMap<Volunteer, VolunteerResponse>();

            CreateMap<VolunteerRequest, VolunteerShift>();
            CreateMap<VolunteerShift, VolunteerResponse>();

            CreateMap<ShiftViewlModel, ShiftResponse>();

        }
    }
}
