using ClassJournals.Domain.Entities.CoursesAndGroups;
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
                .HasForeignKey(g => g.CurrentGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(g => g.Course)
                .WithMany(c => c.Group)
                .HasForeignKey(g => g.GroupId)       // Primary Key може використовуватись як навігацыйний?
                .OnDelete(DeleteBehavior.Cascade);   // DeleteBehavior дублюється, треба утчнити чи так норм?

            builder.HasOne(g => g.GroupSchedule)
                .WithOne(gs => gs.Group)
                .HasForeignKey<GroupSchedule>(gs => gs.ScheduleId);
        }
    }
}