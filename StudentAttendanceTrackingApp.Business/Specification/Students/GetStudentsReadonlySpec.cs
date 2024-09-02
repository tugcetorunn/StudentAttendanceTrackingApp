using Ardalis.Specification;
using StudentAttendanceTrackingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceTrackingApp.Business.Specification.Students
{
    public class GetStudentsReadonlySpec : Specification<Student>
    {
        public GetStudentsReadonlySpec()
        {
            Query.Where(x => x.IsDeleted == false).OrderBy(x => x.Id).AsNoTracking();
        }
    }
}
