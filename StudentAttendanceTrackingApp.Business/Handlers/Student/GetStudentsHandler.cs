using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class GetStudentsHandler : IRequestHandler<GetStudentsQuery, List<Student>>
    {
        private readonly IStudentRepository studentRepository;
        public GetStudentsHandler(IStudentRepository _studentRepository)
        {
            studentRepository = _studentRepository;
        }

        // bir handler ı illaki controller da çağırmak kullanmak zorunda değiliz. herhangi bir metod veya başka bir handlerda da bir handler ı çağırabiliriz mediatr
        // aracılığı ile. ayrıca bir tane değil birden fazla handler çağrılabilir.

        public async Task<List<Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            return await studentRepository.ListAsync(new GetStudentsReadonlySpec(), cancellationToken);
            //var list = await context.Students.ToListAsync(cancellationToken);
            //return list;
        }
    }
}
