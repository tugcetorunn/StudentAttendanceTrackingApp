
namespace StudentAttendanceTrackingApp.Business.Specification.Students
{
    public class GetStudentsReadonlySpec : Specification<Student>
    {
        public GetStudentsReadonlySpec()
        {
            Query.Where(x => x.IsDeleted == false)
                // .Include(x => x.Student) -> ilişkili olduğu entityler var ise burada joinleyebiliyoruz.
                 .OrderBy(x => x.Id).AsNoTracking();
        }
    }
}
