using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceTrackingApp.Business.Commands
{
    public class DeleteLessonCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
