using ClassJournals.Domain.Entities.Users;
using ClassJournals.Domain.Entities.Schedules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassJournals.Domain.ContextConfigurationsParts
{
    public class LectorsScheduleConfiguration : IEntityTypeConfiguration<LectorsSchedule>
    {
        public void Configure(EntityTypeBuilder<LectorsSchedule> builder)
        {
            builder.HasKey(ls => ls.ScheduleId);

            builder.HasMany(ls => ls.Lectures)
                .WithOne(l=>l.LectorsSchedule)
                .HasForeignKey(ls => ls.LectureId);

            builder.HasOne(gl => gl.Lectors)
                .WithOne(l => l.LectorsSchedule)
                .HasForeignKey<Lector>(ls => ls.LectorId);
        }
    }
}