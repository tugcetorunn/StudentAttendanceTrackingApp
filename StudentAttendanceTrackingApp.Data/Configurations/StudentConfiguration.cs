
namespace StudentAttendanceTrackingApp.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students", "satapp");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(x => x.LastName)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(x => x.BirthDate)
                   .IsRequired();

            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.City)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(x => x.CreaDate)
                   .IsRequired()
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(x => x.IsDeleted)
                   .IsRequired();

        }
    }
}
