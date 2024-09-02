using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentAttendanceTrackingApp.Business.Repositories.Abstracts;
using StudentAttendanceTrackingApp.Data;
using StudentAttendanceTrackingApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceTrackingApp.Business.Repositories.Concrete
{
    public class ApiUserRepository : RepositoryBase<ApiUser>, IApiUserRepository
    {
        public ApiUserRepository(SATDbContext dbContext) : base(dbContext)
        {
        }
    }
}
