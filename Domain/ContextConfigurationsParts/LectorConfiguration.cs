using ClassJournals.Domain.Entities.Users;
using ClassJournals.Domain.Entities.Schedules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassJournals.Domain.ContextConfigurationsParts
{
    public class LectorConfiguration : IEntityTypeConfiguration<Lector>
    {
        public void Configure(EntityTypeBuilder<Lector> builder)
        {
            builder.HasKey(l => l.LectorId);

            //builder.Property(l => l.LectorId)
            //    .HasColumnName("Lector Id")
            //    .ValueGeneratedOnUpdate()
            //    .IsRequired();

            builder.Property(s => s.FirstName)
                .HasMaxLength(15).HasColumnType("varchar")
                .HasColumnName("First name");

            builder.Property(s => s.LustName)
                .HasMaxLength(15).HasColumnType("varchar")
                .HasColumnName("Lust name");

            builder.Property(s => s.UserName).IsRequired()
                .HasColumnName("Login");

            builder.Ignore(l => l.FullName);

            builder.Property(s => s.Email).IsRequired();

            builder.HasMany(lo => lo.Lecture)
                .WithOne(lu => lu.Lectors)
                .HasForeignKey(lo => lo.LectureId);

            builder.HasOne(l => l.LectorsSchedule)
                .WithOne(ls => ls.Lectors)
                .HasForeignKey<LectorsSchedule>(ls => ls.ScheduleId);

            builder.HasOne(l => l.Role)
                .WithOne(r => r.Lector)
                .HasForeignKey<UserRoles>(l => l.LectorId);
        }
    }
}