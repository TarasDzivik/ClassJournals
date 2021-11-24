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
            // При мыграції викидає помилку:
            // System.Reflection.TargetInvocationException:
            // Exception has been thrown by the target of an invocation.

            // --->System.InvalidOperationException: A key cannot be configured
            // on 'Lector' because it is a derived type.The key must be configured
            // on the root type 'IdentityUser'.If you did not intend for
            // 'IdentityUser' to be included in the model, ensure that it
            // is not included in a DbSet property on your context, referenced
            // in a configuration call to ModelBuilder, or referenced from
            // a navigation property on a type that is included in the model.

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