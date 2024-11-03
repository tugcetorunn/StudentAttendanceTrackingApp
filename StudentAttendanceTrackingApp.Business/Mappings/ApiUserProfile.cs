
namespace StudentAttendanceTrackingApp.Business.Mappings
{
    public class ApiUserProfile : Profile
    {
        public ApiUserProfile()
        {
            CreateMap<ApiUser, ApiUserDto>().ReverseMap();
        }
    }
}
