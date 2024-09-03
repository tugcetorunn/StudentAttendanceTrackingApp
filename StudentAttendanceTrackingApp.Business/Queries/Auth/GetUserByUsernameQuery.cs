
namespace StudentAttendanceTrackingApp.Business.Queries
{
    public class GetUserByUsernameQuery : IRequest<ApiUser>
    {
        public string UserName { get; set; } 
    }
}
