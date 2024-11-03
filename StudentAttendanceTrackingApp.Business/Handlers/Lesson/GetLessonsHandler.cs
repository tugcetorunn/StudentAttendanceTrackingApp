
namespace StudentAttendanceTrackingApp.Business.Handlers
{
    public class GetLessonsHandler : IRequestHandler<GetLessonsQuery, List<LessonDto>>
    {
        private readonly ILessonRepository lessonRepository;
        private readonly IMapper mapper;
        public GetLessonsHandler(ILessonRepository _lessonRepository, IMapper _mapper)
        {
            lessonRepository = _lessonRepository;
            mapper = _mapper;
        }
        public async Task<List<LessonDto>> Handle(GetLessonsQuery request, CancellationToken cancellationToken)
        {
            var lessons = await lessonRepository.ListAsync(new GetLessonsReadonlySpec(), cancellationToken);
            return mapper.Map<List<LessonDto>>(lessons);    
        }
    }
}
