using Ardalis.Specification;
using StudentAttendanceTrackingApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceTrackingApp.Business.Specification.Users
{
    public class GetByUsernameReadonlySpec : Specification<ApiUser>
    {
        public GetByUsernameReadonlySpec(string username)
        {
            Query.Where(x => x.UserName == username).AsNoTracking();
        }
    }
}
