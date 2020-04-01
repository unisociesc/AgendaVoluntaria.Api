using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.ViewModel;
using AgendaVoluntaria.Api.Views;
using AutoMapper;

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

            CreateMap<VolunteerRequest, UserShift>();
            CreateMap<UserShift, VolunteerResponse>();

            CreateMap<ShiftViewlModel, ShiftResponse>();

            CreateMap<UserShiftRequest, UserShift>();
            CreateMap<UserShift, UserShiftResponse>();
        }
    }
}
