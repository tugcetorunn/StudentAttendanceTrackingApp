using MediatR;
using StudentAttendanceTrackingApp.Business.Commands;
using StudentAttendanceTrackingApp.Business.Repositories.Abstracts;
using StudentAttendanceTrackingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceTrackingApp.Business.Handlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, Student>
    {
        private readonly IStudentRepository studentRepository;
        public CreateStudentHandler(IStudentRepository _studentRepository)
        {
            studentRepository = _studentRepository;
        }
        public async Task<Student> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            // var lastStudent = context.Students.OrderByDescending(x => x.Id).FirstOrDefault();
            // var newStudentId = lastStudent.Id + 1;

            // id için 2. yol
            // int newId = context.Students.Max(x => x.Id) + 1;

            var newStudent = new Student() {
                // Id = newStudentId, (sıradan yeni id atama işini configuration dosyası yapıyor(generatedValueOnAdd))
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                BirthDate = request.BirthDate,
                City = request.City,
                CreaDate = DateTime.UtcNow
            };
            return await studentRepository.AddAsync(newStudent, cancellationToken);
            //var res = await studentRepository.SaveChangesAsync(cancellationToken);
            //if (res > 0)
            //{
            //    return true;
            //}
            //return false;
        }
    }
}
