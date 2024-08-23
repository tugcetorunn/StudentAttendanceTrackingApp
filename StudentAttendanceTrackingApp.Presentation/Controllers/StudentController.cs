using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAttendanceTrackingApp.Data;
using Microsoft.AspNetCore.Mvc.Abstractions;
using StudentAttendanceTrackingApp.Business.Queries;
using StudentAttendanceTrackingApp.Presentation.Common;
using StudentAttendanceTrackingApp.Business.Commands;
using StudentAttendanceTrackingApp.Business.Handlers;
using Microsoft.AspNetCore.Authorization;

namespace StudentAttendanceTrackingApp.Presentation.Controllers
{
    [Route($"{Constant.RouteStudent}")]
    [ApiController]
    [Authorize] // ekleyerek bu controller daki tüm actionlara authorize koşulu veriyoruz. herkese açık olmaktan çıkıyor.
                // bir attribute un ([]) kontrol (çalışma) alanı bir action olabilir, bir controller olabilir veya tüm proje olabilir bunu da program.cs den 
                // setleriz. fakat authorize ı tüm projeye verirsek bu şekilde authorize controller ını da kapsar proje düzgün çalışmaz. bunun için de authorize
                // olmamasını istediğimiz yerlerde allowanonymous kullanabiliriz.
    public class StudentController : ControllerBase
    {
        private readonly IMediator mediator;
        public StudentController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)] // response olasılıkları
        public async Task<ActionResult<List<Student?>>> GetStudents() // IActionResult generic kullanılamıyor, bu yüzden actionResult kullandık.
        {
            var students = await mediator.Send(new GetStudentsQuery());
            if (students != null)
            {
                return Ok(students);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Student?>> GetStudentById(int id)
        {
            var student = await mediator.Send(new GetStudentByIdQuery() { Id = id});
            if (student != null)
            {
                return Ok(student);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateStudent([FromBody] CreateStudentCommand command) // Student olarak da parametre gönderilebilir
        {
            var res = await mediator.Send(command);
            if (res == true)
            {
                return Ok(res);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteStudent(int id)
        {
            var res = await mediator.Send(new DeleteStudentCommand() { Id = id });
            if (res == true)
            {
                return Ok(res);
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<ActionResult<Student?>> UpdateStudent([FromQuery] int id, [FromBody] UpdateStudentCommand command)
        {
            if (command == null)
            {
                return BadRequest("Student data cannot be null.");
            }

            var res = await mediator.Send(command);

            if (res == null)
            {
                return NotFound($"Student with Id = {id} not found.");
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
