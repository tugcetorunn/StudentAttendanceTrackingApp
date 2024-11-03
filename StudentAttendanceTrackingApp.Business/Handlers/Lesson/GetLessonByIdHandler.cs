
namespace StudentAttendanceTrackingApp.Business.Handlers
{
    public class GetLessonByIdHandler : IRequestHandler<GetLessonByIdQuery, LessonDto?>
    {
        private readonly ILessonRepository lessonRepository;
        private readonly IMapper mapper;
        public GetLessonByIdHandler(ILessonRepository _lessonRepository, IMapper _mapper)
        {
            lessonRepository = _lessonRepository;
            mapper = _mapper;
        }
        public async Task<LessonDto?> Handle(GetLessonByIdQuery request, CancellationToken cancellationToken)
        {
            var lesson = await lessonRepository.GetByIdAsync(request.Id, cancellationToken); // id yi direk bu şekilde de verebiliriz. 
            return mapper.Map<LessonDto>(lesson);
        }
    }
}
