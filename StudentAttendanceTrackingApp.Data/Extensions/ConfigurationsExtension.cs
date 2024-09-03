
namespace StudentAttendanceTrackingApp.Data.Extensions
{
    public static class ConfigurationsExtension
    {
        public static void ApplyConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new ApiUserConfiguration());
        }
    }
}
