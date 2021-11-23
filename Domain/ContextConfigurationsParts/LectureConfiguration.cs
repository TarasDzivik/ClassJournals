using ClassJournals.Domain.Entities.CoursesAndGroups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassJournals.Domain.ContextConfigurationsParts
{
    public class LectureConfiguration : IEntityTypeConfiguration<Lecture>
    {
        public void Configure(EntityTypeBuilder<Lecture> builder)
        {
            builder.HasKey(l => l.LectureId);

            builder.Property(l => l.Name).HasMaxLength(40)
                .HasColumnType("varchar").HasColumnName("Предмет")
                .IsRequired();

            // Треба подумати якими як саме буде обраховуватись протяжність лекції
            // також чи це навігаційна властивість чи звичайна інформаційна
            // (поки маю сили, запишу лише як ідею на завта)

            builder.Property(l => l.Hours).HasColumnName("Години");

            builder.Property(l => l.Raiting).HasColumnName("Оцінка")
                .HasMaxLength(2).HasColumnType("INT");

            // Також необхідно розібратись в своїй голові
            // чи Lecture - це назва предмету і для обрахунку
            // відвідуваності необхідно створювати окрему таблицю
            // зі списком лекцій чи використовувати для цього GroupeSchedule?

            builder.HasOne(lu => lu.Lectors)
                .WithMany(lo => lo.Lectures)
                .HasForeignKey(lu => lu.CurrentLectorId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}