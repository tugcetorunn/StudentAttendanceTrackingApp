
namespace StudentAttendanceTrackingApp.Business.Commands
{
    public class CreateLessonCommand : IRequest<Lesson>
    {
        public string Name { get; set; }
    }
}
