using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentAttendanceTrackingApp.Business.Queries;
using StudentAttendanceTrackingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceTrackingApp.Business.Handlers
{
    public class GetStudentsHandler : IRequestHandler<GetStudentsQuery, List<Student>>
    {
        private readonly SATDbContext context;
        public GetStudentsHandler(SATDbContext _context)
        {
            context = _context;
        }
        public async Task<List<Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var list = await context.Students.ToListAsync(cancellationToken);
            return list;
        }
    }
}
