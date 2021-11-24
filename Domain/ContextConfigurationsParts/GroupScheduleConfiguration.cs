using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClassJournals.Domain.Entities.Schedules;
using ClassJournals.Domain.Entities.CoursesAndGroups;

namespace ClassJournals.Domain.ContextConfigurationsParts
{
    public class GroupScheduleConfiguration : IEntityTypeConfiguration<GroupSchedule>
    {
        public void Configure(EntityTypeBuilder<GroupSchedule> builder)
        {
            builder.HasKey(gs => gs.ScheduleId);

            builder.HasMany(gs => gs.Lecture)
                .WithOne(l => l.GroupSchedule)
                .HasForeignKey(gs=>gs.LectureId);

            builder.HasOne(gs => gs.Group)
                .WithOne(g => g.GroupSchedule)
                .HasForeignKey<Group>(gs => gs.GroupId);

        }
    }
}