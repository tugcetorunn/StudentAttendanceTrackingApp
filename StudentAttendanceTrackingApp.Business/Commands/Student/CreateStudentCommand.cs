
namespace StudentAttendanceTrackingApp.Business.Commands
{
    public class CreateStudentCommand : IRequest<Response<Student>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
    }
}
