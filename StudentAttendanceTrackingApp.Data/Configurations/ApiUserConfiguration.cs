
namespace StudentAttendanceTrackingApp.Data.Configurations
{
    public class ApiUserConfiguration : IEntityTypeConfiguration<ApiUser>
    {
        public void Configure(EntityTypeBuilder<ApiUser> builder)
        {
            builder.ToTable("ApiUsers", "satapp");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(x => x.LastName)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.CreaDate)
                   .IsRequired()
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(x => x.IsDeleted)
                   .IsRequired();
        }
    }
}
