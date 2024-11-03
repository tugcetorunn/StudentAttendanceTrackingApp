
namespace StudentAttendanceTrackingApp.Business.Queries
{
    public class GetLessonByIdQuery : IRequest<LessonDto>
    {
        public int Id { get; set; }
    }
}
