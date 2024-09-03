
namespace StudentAttendanceTrackingApp.Business.Specification.Users
{
    public class GetByUsernameReadonlySpec : Specification<ApiUser>
    {
        public GetByUsernameReadonlySpec(string username)
        {
            Query.Where(x => x.UserName == username).AsNoTracking();
        }
    }
}
