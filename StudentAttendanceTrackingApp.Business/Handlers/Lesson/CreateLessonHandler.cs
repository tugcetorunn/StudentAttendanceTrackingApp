
namespace StudentAttendanceTrackingApp.Business.Handlers
{
    public class CreateLessonHandler : IRequestHandler<CreateLessonCommand, LessonDto>
    {
        private readonly ILessonRepository lessonRepository;
        private readonly IMapper mapper;

        public CreateLessonHandler(ILessonRepository _lessonRepository, IMapper _mapper)
        {
            lessonRepository = _lessonRepository;
            mapper = _mapper;
        }

        public async Task<LessonDto> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
        {
            var newLesson = new Lesson() 
            { 
                CreaDate = DateTime.UtcNow,
                Name = request.Name,
                IsDeleted = false
            };

            var lesson = await lessonRepository.AddAsync(newLesson, cancellationToken);
            return mapper.Map<LessonDto>(lesson);
        }
    }
}
