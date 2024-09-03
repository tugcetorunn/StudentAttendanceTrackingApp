
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

            return await lessonRepository.AddAsync(newLesson, cancellationToken);
        }
    }
}
