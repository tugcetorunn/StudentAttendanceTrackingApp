using MediatR;
using StudentAttendanceTrackingApp.Business.Queries;
using StudentAttendanceTrackingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceTrackingApp.Business.Handlers
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, Student?>
    {
        private readonly SATDbContext context;
        public GetStudentByIdHandler(SATDbContext _context)
        {
            context = _context;
        }
        public async Task<Student?> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await context.Students.FindAsync(request.Id);
            return student;
        }
    }
}
