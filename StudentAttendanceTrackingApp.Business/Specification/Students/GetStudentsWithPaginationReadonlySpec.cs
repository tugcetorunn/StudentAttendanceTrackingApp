
namespace StudentAttendanceTrackingApp.Business.Specification.Students
{
    public class GetStudentsWithPaginationReadonlySpec : Specification<Student>
    {
        public GetStudentsWithPaginationReadonlySpec(int skip, int take)
        {
            Query.Where(x => x.IsDeleted == false)
                 .Skip(skip)
                 .Take(take)
                 .OrderBy(x => x.Id)
                 .AsNoTracking();
        }
    }
}
