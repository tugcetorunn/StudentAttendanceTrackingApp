
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
