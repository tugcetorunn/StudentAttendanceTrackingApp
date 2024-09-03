
namespace StudentAttendanceTrackingApp.Business.Specification.Students
{
    public class GetStudentsReadonlySpec : Specification<Student>
    {
        public GetStudentsReadonlySpec()
        {
            Query.Where(x => x.IsDeleted == false).OrderBy(x => x.Id).AsNoTracking();
        }
    }
}
