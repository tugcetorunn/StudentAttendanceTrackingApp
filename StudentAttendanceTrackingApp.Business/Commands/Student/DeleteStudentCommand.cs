
namespace StudentAttendanceTrackingApp.Business.Commands
{
    public class DeleteStudentCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
