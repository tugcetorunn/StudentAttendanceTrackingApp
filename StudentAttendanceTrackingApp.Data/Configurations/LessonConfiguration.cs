﻿
namespace StudentAttendanceTrackingApp.Data.Configurations
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.ToTable("Lesson", "satapp");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(x => x.IsDeleted)
                   .IsRequired();

            builder.Property(x => x.CreaDate)
                   .IsRequired()
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
