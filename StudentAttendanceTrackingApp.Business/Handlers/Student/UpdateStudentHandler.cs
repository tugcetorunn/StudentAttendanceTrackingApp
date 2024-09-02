using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, Student?>
    {
        //private readonly SATDbContext context;
        //public UpdateStudentHandler(SATDbContext _context)
        //{
        //    context = _context;
        //}

        private readonly IStudentRepository studentRepository;
        public UpdateStudentHandler(IStudentRepository _studentRepository)
        {
            studentRepository = _studentRepository;
        }

        public async Task<Student?> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            //var updateStudent = await context.Students.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            var updateStudent = await studentRepository.GetByIdAsync(request.Id, cancellationToken);

            if (updateStudent != null)
            {
                updateStudent.FirstName = request.FirstName;
                updateStudent.LastName = request.LastName;
                updateStudent.Email = request.Email;
                updateStudent.BirthDate = request.BirthDate;
                updateStudent.City = request.City;

                await studentRepository.SaveChangesAsync();

                return updateStudent;
            }
            return updateStudent;
        }
    }
}
