
namespace StudentAttendanceTrackingApp.Business.Commands
{
    public class CreateLessonCommand : IRequest<LessonDto>
    {
        public string Name { get; set; }
    }
}
