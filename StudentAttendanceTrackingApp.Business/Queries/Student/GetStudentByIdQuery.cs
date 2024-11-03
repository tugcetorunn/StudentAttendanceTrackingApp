
using System.ComponentModel.DataAnnotations;

namespace StudentAttendanceTrackingApp.Business.Queries
{
    public class GetStudentByIdQuery : IRequest<Response<StudentDto>>
    {
        // [Required] data annotation yöntemi, handler içinde yaptığımız kontrol (custom validation control) gibi bir başka yöntem
        public int Id { get; set; }
    }
}
