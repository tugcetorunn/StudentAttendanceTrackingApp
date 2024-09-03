
namespace StudentAttendanceTrackingApp.Business.Repositories.Concrete
{
    public class ApiUserRepository : RepositoryBase<ApiUser>, IApiUserRepository
    {
        public ApiUserRepository(SATDbContext dbContext) : base(dbContext)
        {
        }
    }
}
