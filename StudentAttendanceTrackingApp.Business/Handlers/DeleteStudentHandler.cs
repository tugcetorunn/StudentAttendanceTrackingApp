using MediatR;
using StudentAttendanceTrackingApp.Business.Commands;
using StudentAttendanceTrackingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceTrackingApp.Business.Handlers
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly SATDbContext context;
        public DeleteStudentHandler(SATDbContext _context)
        {
            context = _context;
        }
        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var delStudent = await context.Students.FindAsync(request.Id, cancellationToken);
            if (delStudent != null)
            {
                delStudent.IsDeleted = true;
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
