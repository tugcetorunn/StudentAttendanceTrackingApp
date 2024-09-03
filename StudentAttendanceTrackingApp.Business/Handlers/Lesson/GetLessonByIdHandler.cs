
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
            return await lessonRepository.GetByIdAsync(request.Id, cancellationToken); // id yi direk bu şekilde de verebiliriz. 
        }
    }
}
