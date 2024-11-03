
namespace StudentAttendanceTrackingApp.Business.Mappings
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            // Automapper 3. adım profile class larının oluşturulup mapping in gerçekleştirilmesi
            // <Source, Destination>
            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}
