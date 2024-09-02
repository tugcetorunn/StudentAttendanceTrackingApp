using Ardalis.Specification;
using StudentAttendanceTrackingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceTrackingApp.Business.Specification.Lessons
{
    public class GetLessonByIdReadonlySpec : Specification<Lesson>
    {
        public GetLessonByIdReadonlySpec(int id)
        {
            Query.Where(x => x.Id == id).AsNoTracking();
        }
    }
}
