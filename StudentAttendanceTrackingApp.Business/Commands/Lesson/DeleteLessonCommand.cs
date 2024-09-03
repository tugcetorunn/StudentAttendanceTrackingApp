
namespace StudentAttendanceTrackingApp.Business.Commands
{
    public class DeleteLessonCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
