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
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository // repositoryBase classı içinde tüm crud işlemleri ve fazlası var
    {
        public StudentRepository(SATDbContext dbContext) : base(dbContext) // injection ı repositoryBase sağlıyor.
        {

        }
        
    }
}
