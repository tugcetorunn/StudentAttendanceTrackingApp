
namespace StudentAttendanceTrackingApp.Presentation.Extensions
{
    public static class MappingProfilesRegisterExtension
    {
        public static void AutoMapperProfilesRegister(this IServiceCollection services)
        {
            // Automapper 5. adım profiles registiratiom
            services.AddAutoMapper(typeof(StudentProfile));
            services.AddAutoMapper(typeof(LessonProfile));
            services.AddAutoMapper(typeof(ApiUserProfile));
        }
    }
}
