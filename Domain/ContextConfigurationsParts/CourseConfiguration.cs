using ClassJournals.Domain.Entities.CoursesAndGroups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassJournals.Domain.ContextConfigurationsParts
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.CourseId);

            builder.Property(c => c.Name).HasMaxLength(30)
                .HasColumnType("varchar").HasColumnName("Курс")
                .IsRequired();

            builder.Property(c => c.TotalHours).HasColumnName("Годин");

            builder.HasMany(g => g.Group)
                .WithOne(s => s.Course)
                .HasForeignKey(g => g.CurrentCourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}