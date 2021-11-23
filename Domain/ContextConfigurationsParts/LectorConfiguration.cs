using ClassJournals.Domain.Entities;
using ClassJournals.Domain.Entities.CoursesAndGroups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassJournals.Domain.ContextConfigurationsParts
{
    public class LectorConfiguration : IEntityTypeConfiguration<Lector>
    {
        public void Configure(EntityTypeBuilder<Lector> builder)
        {
            builder.HasKey(l => l.LectorId);

            builder.Property(s => s.FirstName).IsRequired()
                .HasMaxLength(15).HasColumnType("varchar")
                .HasColumnName("First name");
            builder.Property(s => s.LustName).IsRequired()
                .HasMaxLength(15).HasColumnType("varchar")
                .HasColumnName("Lust name");

            builder.Property(s => s.UserName).IsRequired()
                .HasColumnName("Login");
            builder.Property(s => s.Email).IsRequired();

            builder.HasMany(lo => lo.Lectures)
                .WithOne(lu => lu.Lectors)
                .HasForeignKey(lo => lo.LectureId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(l => l.LectorsSchedule)
                .WithOne(ls => ls.Lector)
                .HasForeignKey<LectorsSchedule>(ls => ls.ScheduleId);
        }
    }
}
