using MediatR;
using StudentAttendanceTrackingApp.Business.Queries;
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
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, Student?>
    {
        // ardalis specification ile repository design pattern ını kullanacağımız için handler lardaki context i repository tarafına vererek handler
        // class larını bir katman daha soyutlaştırmış oluyoruz.

        //private readonly SATDbContext context;
        //public GetStudentsHandler(SATDbContext _context)
        //{
        //    context = _context;
        //}

        private readonly IStudentRepository studentRepository;
        public GetStudentByIdHandler(IStudentRepository _studentRepository)
        {
            studentRepository = _studentRepository;
        }

        public async Task<Student?> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            //var student = await context.Students.FindAsync(request.Id);
            //return student;
            var spec = new GetStudentByIdReadonlySpec(request.Id);
            return await studentRepository.GetBySpecAsync(spec, cancellationToken);
        }
    }
}
