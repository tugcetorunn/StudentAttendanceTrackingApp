using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentAttendanceTrackingApp.Business.Repositories.Abstracts;
using StudentAttendanceTrackingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceTrackingApp.Business.Repositories.Concrete
{
    public class LessonRepository : RepositoryBase<Lesson>, ILessonRepository
    {
        public LessonRepository(SATDbContext dbContext) : base(dbContext)
        {
        }
    }
}
