
namespace StudentAttendanceTrackingApp.Business.Commands
{
    public class SignInCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}
