
namespace StudentAttendanceTrackingApp.Business.Commands
{
    public class UpdateLessonCommand : IRequest<LessonDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
