
namespace StudentAttendanceTrackingApp.Business.Commands
{
    public class UpdateStudentCommand : IRequest<Response<StudentDto?>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
    }
}
