using MediatR;
using StudentAttendanceTrackingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceTrackingApp.Business.Commands
{
    public class UpdateLessonCommand : IRequest<Lesson>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
