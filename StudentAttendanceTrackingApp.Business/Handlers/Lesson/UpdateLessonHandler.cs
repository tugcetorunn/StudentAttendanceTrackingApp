
namespace StudentAttendanceTrackingApp.Business.Handlers
{
    public class UpdateLessonHandler : IRequestHandler<UpdateLessonCommand, LessonDto?>
    {
        private readonly ILessonRepository lessonRepository;
        private readonly IMapper mapper;
        public UpdateLessonHandler(ILessonRepository _lessonRepository, IMapper _mapper)
        {
            lessonRepository = _lessonRepository;
            mapper = _mapper;
        }
        public async Task<LessonDto?> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
        {
            var updateLesson = await lessonRepository.GetByIdAsync(request.Id, cancellationToken); // spec kullanamayız çünkü orada asNoTracking metodu 
                                                                                                   // yani değişikliği alacak bir gözcü yok.

            if (updateLesson != null)
            {
                updateLesson.Name = request.Name;

                await lessonRepository.SaveChangesAsync(cancellationToken);

                return mapper.Map<LessonDto>(updateLesson);
            }

            return mapper.Map<LessonDto>(updateLesson);
        }
    }
}
