
namespace StudentAttendanceTrackingApp.Business.Queries
{
    public class GetUserByUsernameQuery : IRequest<ApiUserDto>
    {
        public string UserName { get; set; } 
    }
}
