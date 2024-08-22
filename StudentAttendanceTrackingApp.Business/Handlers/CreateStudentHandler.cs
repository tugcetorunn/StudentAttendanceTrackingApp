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
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, bool>
    {
        private readonly SATDbContext context;
        public CreateStudentHandler(SATDbContext _context)
        {
            context = _context;
        }
        public async Task<bool> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var lastStudent = context.Students.OrderByDescending(x => x.Id).FirstOrDefault();
            var newStudentId = lastStudent.Id + 1;

            // id için 2. yol
            // int newId = context.Students.Max(x => x.Id) + 1;

            var newStudent = new Student() {
                Id = newStudentId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                BirthDate = request.BirthDate,
                City = request.City,
                CreaDate = DateTime.UtcNow
            };
            await context.Students.AddAsync(newStudent);
            var res = await context.SaveChangesAsync();
            if (res>0)
            {
                return true;
            }
            return false;
        }
    }
}
