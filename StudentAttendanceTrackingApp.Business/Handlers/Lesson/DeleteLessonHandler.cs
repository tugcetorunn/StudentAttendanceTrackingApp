
namespace StudentAttendanceTrackingApp.Business.Handlers
{
    public class DeleteLessonHandler : IRequestHandler<DeleteLessonCommand, bool>
    {
        private readonly ILessonRepository lessonRepository;
        public DeleteLessonHandler(ILessonRepository _lessonRepository)
        {
            lessonRepository = _lessonRepository;
        }

        public async Task<bool> Handle(DeleteLessonCommand request, CancellationToken cancellationToken)
        {
            var del = await lessonRepository.GetByIdAsync(request.Id, cancellationToken);
            if (del != null)
            {
                del.IsDeleted = true;
                await lessonRepository.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
