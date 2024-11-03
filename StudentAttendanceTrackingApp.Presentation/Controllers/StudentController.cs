
using Microsoft.AspNetCore.Mvc;
using StudentAttendanceTrackingApp.Business.Dtos;
using StudentAttendanceTrackingApp.Business.Queries.Student;

namespace StudentAttendanceTrackingApp.Presentation.Controllers
{
    [Route($"{Constant.RouteStudent}")]
    [ApiController]
    [Authorize] // ekleyerek bu controller daki tüm actionlara authorize koşulu veriyoruz. herkese açık olmaktan çıkıyor.
                // bir attribute un ([]) kontrol (çalışma) alanı bir action olabilir, bir controller olabilir veya tüm proje olabilir bunu da program.cs den 
                // setleriz. fakat authorize ı tüm projeye verirsek bu şekilde authorize controller ını da kapsar proje düzgün çalışmaz. bunun için de authorize
                // olmamasını istediğimiz yerlerde allowanonymous kullanabiliriz.
    public class StudentController : SATBaseController // controller ları aynı zamanda bir ara katmandan da geçirebiliriz. StudentController : ControllerBase
                                                    // şeklinde kullandığımızda controller child, controllerBase parent oluyor. araya katman koyarak yani
                                                    // controller ı örn. controllerX ten miras alıyor yapsak controllerX de controllerBase den miras alsın ki
                                                    // controller özelliklerini kaybetmesin. bu durumda controllerX parent, controllerBase grandparent oluyor ve
                                                    // controller için ek özellik ekleyebileceğimiz bir katman elde etmiş oluruz. Yeni bir controller ekleyerek
                                                    // uygulayalım.
    {
        public StudentController(IMediator mediator) : base(mediator)
        {
            // injection görevini ara katmana devretmiş olduk.
        }

        [HttpGet]
        [ProducesResponseType(typeof(Response<List<StudentDto>>), 200)]
        [ProducesResponseType(typeof(Response<List<StudentDto>>), 400)]
        [ProducesResponseType(typeof(Response<List<StudentDto>>), 401)]
        [ProducesResponseType(typeof(Response<List<StudentDto>>), 500)] // response olasılıkları
        public async Task<IActionResult> GetStudents()
        {
            var res = await mediator.Send(new GetStudentsQuery());
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        // pagination 2. adım

        [HttpGet("GetStudentsWithPagination")]
        [ProducesResponseType(typeof(Response<List<StudentDto>>), 200)]
        [ProducesResponseType(typeof(Response<List<StudentDto>>), 400)]
        [ProducesResponseType(typeof(Response<List<StudentDto>>), 401)]
        [ProducesResponseType(typeof(Response<List<StudentDto>>), 500)]
        public async Task<IActionResult> GetStudentsWithPagination([FromQuery] GetStudentsWithPaginationQuery query) 
        {
            var res = await mediator.Send(query);
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Response<StudentDto>), 200)]
        [ProducesResponseType(typeof(Response<StudentDto>), 400)]
        [ProducesResponseType(typeof(Response<StudentDto>), 401)]
        [ProducesResponseType(typeof(Response<StudentDto>), 404)]
        [ProducesResponseType(typeof(Response<StudentDto>), 500)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var student = await mediator.Send(new GetStudentByIdQuery() { Id = id});
            if (student != null)
            {
                return Ok(student);
            }
            return BadRequest();
        }

        [HttpPost]
        [ProducesResponseType(typeof(Response<StudentDto>), 201)]
        [ProducesResponseType(typeof(Response<StudentDto>), 400)]
        [ProducesResponseType(typeof(Response<StudentDto>), 401)]
        [ProducesResponseType(typeof(Response<StudentDto>), 500)]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentCommand command) // Student olarak da parametre gönderilebilir
        {
            var res = await mediator.Send(command);
            if (res != null)
            {
                return Ok(res);
            }
            return Unauthorized(res);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Response<int>), 200)]
        [ProducesResponseType(typeof(Response<int>), 400)]
        [ProducesResponseType(typeof(Response<int>), 401)]
        [ProducesResponseType(typeof(Response<int>), 404)]
        [ProducesResponseType(typeof(Response<int>), 500)]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var res = await mediator.Send(new DeleteStudentCommand() { Id = id });
            if (res.IsSuccess == true)
            {
                return Ok(res);
            }
            return NotFound();
        }

        [HttpPut]
        [ProducesResponseType(typeof(Response<StudentDto?>), 200)]
        [ProducesResponseType(typeof(Response<StudentDto?>), 400)]
        [ProducesResponseType(typeof(Response<StudentDto?>), 401)]
        [ProducesResponseType(typeof(Response<StudentDto?>), 404)]
        [ProducesResponseType(typeof(Response<StudentDto?>), 500)]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentCommand command)
        {
            if (command == null)
            {
                return BadRequest("Student data cannot be null.");
            }

            var res = await mediator.Send(command);

            if (res == null)
            {
                return NotFound($"Student with Id = {command.Id} not found.");
            }

            return Ok(res);
        }

        // aşağıdaki gibi de parametre gönderilebilir.

        //[HttpPut]
        //public async Task<ActionResult<Student?>> UpdateStudent2([FromQuery] int id, [FromBody] Student student)
        //{
        //    if (student == null)
        //    {
        //        return BadRequest("Student data cannot be null.");
        //    }

        //    var res = await mediator.Send(new UpdateStudentCommand()
        //    {
        //        Id = id,
        //        FirstName = student.FirstName,
        //        LastName = student.LastName,
        //        BirthDate = student.BirthDate,
        //        Email = student.Email,
        //        City = student.City
        //    });

        //    if (res == null)
        //    {
        //        return NotFound($"Student with Id = {id} not found.");
        //    }

        //    return Ok(res);
        //}
    }
}
