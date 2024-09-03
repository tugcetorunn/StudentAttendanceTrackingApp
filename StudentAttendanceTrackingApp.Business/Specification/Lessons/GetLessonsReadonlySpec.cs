
namespace StudentAttendanceTrackingApp.Business.Specification.Lessons
{
    public class GetLessonsReadonlySpec : Specification<Lesson>
    {
        public GetLessonsReadonlySpec()
        {
            Query.Where(x => x.IsDeleted == false).OrderBy(x => x.Id).AsNoTracking();
        }
    }
}
