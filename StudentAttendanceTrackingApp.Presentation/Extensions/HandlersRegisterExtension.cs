
namespace StudentAttendanceTrackingApp.Presentation.Extensions
{
    public static class HandlersRegisterExtension
    {
        public static void RegisterHandlers(this IServiceCollection services)
        {
            // handlerlar için bulunduğu assembly deki (derleme) tüm MediatR handler sınıflarını bulmak ve kaydetmek için kullanılır.
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetStudentsHandler).Assembly)); // bir tanesini kayıt etmek yeterli
        }
    }
}
