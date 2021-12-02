using ClassJournals.Domain.Entities.CoursesAndGroups;
using ClassJournals.Domain.Entities.Schedules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassJournals.Domain.ContextConfigurationsParts
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(g => g.GroupId);

            builder.Property(g => g.Name).HasMaxLength(10)
                .HasColumnType("varchar").HasColumnName("Група")
                .IsRequired();

            builder.HasMany(g => g.Students)
                .WithOne(s => s.Groups)
                .HasForeignKey(g => g.Group);

            builder.HasOne(g => g.Course)
                .WithMany(c => c.Group)
                .HasForeignKey(g => g.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(g => g.GroupSchedule)
                .WithOne(gs => gs.Group)
                .HasForeignKey<GroupSchedule>(gs => gs.ScheduleId);
        }
    }
}