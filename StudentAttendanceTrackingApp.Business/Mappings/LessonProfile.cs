
namespace StudentAttendanceTrackingApp.Business.Mappings
{
    public class LessonProfile : Profile
    {
        public LessonProfile()
        {
            CreateMap<Lesson, LessonDto>().ReverseMap();
        }
    }
}
