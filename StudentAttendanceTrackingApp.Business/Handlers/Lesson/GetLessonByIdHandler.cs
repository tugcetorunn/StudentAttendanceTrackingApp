using MediatR;
using StudentAttendanceTrackingApp.Business.Queries;
using StudentAttendanceTrackingApp.Business.Repositories.Abstracts;
using StudentAttendanceTrackingApp.Business.Specification.Lessons;
using StudentAttendanceTrackingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceTrackingApp.Business.Handlers
{
    public class GetLessonByIdHandler : IRequestHandler<GetLessonByIdQuery, Lesson?>
    {
        private readonly ILessonRepository lessonRepository;
        public GetLessonByIdHandler(ILessonRepository _lessonRepository)
        {
            lessonRepository = _lessonRepository;
        }
        public async Task<Lesson?> Handle(GetLessonByIdQuery request, CancellationToken cancellationToken)
        {
            //return await lessonRepository.GetBySpecAsync(new GetLessonByIdReadonlySpec(request.Id), cancellationToken);
            return await lessonRepository.GetByIdAsync(request.Id, cancellationToken); // id yi direk bu şekilde de verebiliriz. 
        }
    }
}
