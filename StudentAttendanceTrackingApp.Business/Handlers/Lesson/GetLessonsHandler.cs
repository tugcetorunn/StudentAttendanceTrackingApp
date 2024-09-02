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
    public class GetLessonsHandler : IRequestHandler<GetLessonsQuery, List<Lesson>>
    {
        private readonly ILessonRepository lessonRepository;
        public GetLessonsHandler(ILessonRepository _lessonRepository)
        {
            lessonRepository = _lessonRepository;
        }
        public async Task<List<Lesson>> Handle(GetLessonsQuery request, CancellationToken cancellationToken)
        {
            return await lessonRepository.ListAsync(new GetLessonsReadonlySpec(), cancellationToken);
        }
    }
}
