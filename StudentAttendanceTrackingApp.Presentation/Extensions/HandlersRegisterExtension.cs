using StudentAttendanceTrackingApp.Business.Handlers;

namespace StudentAttendanceTrackingApp.Presentation.Extensions
{
    public static class HandlersRegisterExtension
    {
        public static void RegisterHandlers(this IServiceCollection services)
        {
            // handlerlar için bulunduğu assembly deki (derleme) tüm MediatR handler sınıflarını bulmak ve kaydetmek için kullanılır.
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetStudentsHandler).Assembly)); // bir tanesini kayıt etmek yeterli
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetStudentByIdHandler).Assembly));
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateStudentHandler).Assembly));
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeleteStudentHandler).Assembly));
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UpdateStudentHandler).Assembly));

            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(SignInHandler).Assembly));

            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetLessonsHandler).Assembly));
        }
    }
}
