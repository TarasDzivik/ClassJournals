using ClassJournals.Domain.Entities.JoiningEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassJournals.Domain.ContextConfigurationsParts.MarginTablesConfigurations
{
    public class GroupsLecturesConfiguration : IEntityTypeConfiguration<GroupsLectures>
    {
        public void Configure(EntityTypeBuilder<GroupsLectures> builder)
        {
            builder.HasKey(sl => new { sl.GroupId, sl.LectureId });

            builder.HasOne(gl => gl.Group)
                .WithMany(g => g.GroupsLectures)
                .HasForeignKey(gl => gl.GroupId);

            builder.HasOne(sl => sl.Lecture)
                .WithMany(l => l.GroupsLectures)
                .HasForeignKey(sl => sl.LectureId);
        }
    }
}
