
using StudentAttendanceTrackingApp.Business.Dtos;

namespace StudentAttendanceTrackingApp.Presentation.Controllers
{
    [Route($"{Constant.RouteLesson}")]
    [ApiController]
    public class LessonController : SATBaseController
    {
        public LessonController(IMediator _mediator) : base(_mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<List<LessonDto>>> GetLessons() // bir işlem diğerini bloklamasın diye async metod yapıyoruz genelde.
        {
            var res = await mediator.Send(new GetLessonsQuery());
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LessonDto>> GetLessonById(int id)
        {
            var res = await mediator.Send(new GetLessonByIdQuery() { Id = id });
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<LessonDto>> CreateLesson([FromBody] CreateLessonCommand command)
        {
            var res = await mediator.Send(new CreateLessonCommand() { Name = command.Name });
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteLesson(int id)
        {
            var res = await mediator.Send(new DeleteLessonCommand() { Id = id });
            if (res)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpPut]
        public async Task<ActionResult<LessonDto>> UpdateLesson([FromBody] UpdateLessonCommand command)
        {
            var res = await mediator.Send(command);
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();
        }
    }
}
