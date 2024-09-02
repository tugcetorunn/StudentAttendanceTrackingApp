using MediatR;
using StudentAttendanceTrackingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceTrackingApp.Business.Commands
{
    public class CreateLessonCommand : IRequest<Lesson>
    {
        public string Name { get; set; }
    }
}
