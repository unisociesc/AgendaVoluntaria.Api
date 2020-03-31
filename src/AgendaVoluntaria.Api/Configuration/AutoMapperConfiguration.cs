using AutoMapper;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Views;

namespace AgendaVoluntaria.Api.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<UserRequest, User>();
            CreateMap<User, UserResponse>();
            CreateMap<User, LoginResponse>();

            CreateMap<ShiftRequest, Shift>();
            CreateMap<Shift, ShiftResponse>();

        }
    }
}
