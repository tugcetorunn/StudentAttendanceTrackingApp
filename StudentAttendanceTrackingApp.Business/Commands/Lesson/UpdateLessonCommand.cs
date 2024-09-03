
namespace StudentAttendanceTrackingApp.Business.Commands
{
    public class UpdateLessonCommand : IRequest<Lesson>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
