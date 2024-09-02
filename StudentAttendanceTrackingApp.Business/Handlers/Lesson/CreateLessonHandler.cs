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
    public class CreateLessonHandler : IRequestHandler<CreateLessonCommand, Lesson>
    {
        private readonly ILessonRepository lessonRepository;

        public CreateLessonHandler(ILessonRepository _lessonRepository)
        {
            lessonRepository = _lessonRepository;
        }

        public async Task<Lesson> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
        {
            var newLesson = new Lesson() 
            { 
                CreaDate = DateTime.UtcNow,
                Name = request.Name,
                IsDeleted = false
            };

            return await lessonRepository.AddAsync(newLesson);
        }
    }
}
