
namespace StudentAttendanceTrackingApp.Business.Handlers
{
    public class UpdateLessonHandler : IRequestHandler<UpdateLessonCommand, Lesson?>
    {
        private readonly ILessonRepository lessonRepository;
        public UpdateLessonHandler(ILessonRepository _lessonRepository)
        {
            lessonRepository = _lessonRepository;
        }
        public async Task<Lesson?> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
        {
            var updateLesson = await lessonRepository.GetByIdAsync(request.Id, cancellationToken); // spec kullanamayız çünkü orada asNoTracking metodu 
                                                                                                   // yani değişikliği alacak bir gözcü yok.

            if (updateLesson != null)
            {
                updateLesson.Name = request.Name;

                await lessonRepository.SaveChangesAsync(cancellationToken);

                return updateLesson;
            }

            return updateLesson;
        }
    }
}
