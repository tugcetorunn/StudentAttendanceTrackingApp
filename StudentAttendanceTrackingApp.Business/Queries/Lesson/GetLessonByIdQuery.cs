using MediatR;
using StudentAttendanceTrackingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceTrackingApp.Business.Queries
{
    public class GetLessonByIdQuery : IRequest<Lesson>
    {
        public int Id { get; set; }
    }
}
