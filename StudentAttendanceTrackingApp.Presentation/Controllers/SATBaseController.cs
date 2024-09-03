
using Microsoft.EntityFrameworkCore.Design.Internal;

namespace StudentAttendanceTrackingApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SATBaseController : ControllerBase
    {
        // injection ları burada tanımlayabilir bizden miras alan controller ın da cconstructor da ürettiği ımediator değerini buraya gönderip
        // buradan atama yapmasını sağlayabiliriz. aşağıdaki gibi;

        public readonly IMediator mediator;
        public SATBaseController(IMediator _mediator)
        {
            mediator = _mediator;
        }
    }
}
