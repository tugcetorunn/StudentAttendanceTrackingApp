using MediatR;
using StudentAttendanceTrackingApp.Business.Commands;
using StudentAttendanceTrackingApp.Business.Repositories.Abstracts;
using StudentAttendanceTrackingApp.Business.Specification.Students;
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
        //private readonly SATDbContext context;
        //public DeleteStudentHandler(SATDbContext _context)
        //{
        //    context = _context;
        //}

        private readonly IStudentRepository studentRepository;
        public DeleteStudentHandler(IStudentRepository _studentRepository)
        {
            studentRepository = _studentRepository;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            //var delStudent = await context.Students.FindAsync(request.Id, cancellationToken);

            var delStudent = await studentRepository.GetByIdAsync(request.Id, cancellationToken); // spec kullanamayız çünkü orada asNoTracking metodu 
                                                                                                  // yani değişikliği alacak bir gözcü yok.
            
            if (delStudent != null)
            {
                delStudent.IsDeleted = true;
                await studentRepository.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
