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
        private readonly SATDbContext dbContext;
        public StudentRepository(SATDbContext _dbContext) : base(_dbContext) // injection ı repositoryBase sağlıyor.
        {
            dbContext = _dbContext;
        }

        public async Task<int> GetMaxId(CancellationToken cancellationToken)
        {
            return await dbContext.Set<Student>().MaxAsync(x => x.Id ,cancellationToken);
        }
    }
}
