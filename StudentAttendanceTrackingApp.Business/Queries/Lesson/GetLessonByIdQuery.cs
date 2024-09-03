
namespace StudentAttendanceTrackingApp.Business.Queries
{
    public class GetLessonByIdQuery : IRequest<Lesson>
    {
        public int Id { get; set; }
    }
}
