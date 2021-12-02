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
                .IsUnicode(true).IsRequired();

            // Треба подумати якими як саме буде обраховуватись протяжність лекції
            // також чи це навігаційна властивість чи звичайна інформаційна
            
            builder.Property(l => l.Hours).HasColumnName("Тривалысть лекцій");

            builder.Property(l => l.Raiting).HasColumnName("Оцінка")
                .HasMaxLength(2).HasDefaultValue(0);

            builder.HasOne(lu => lu.Lectors)
                .WithMany(lo => lo.Lecture)
                .HasForeignKey(lu => lu.LectureId);
            // Якось дуже заплутано получається, подивлюсь по міграції що там вийде...
            builder.HasOne(l => l.LectorsSchedule)
                .WithMany(gs => gs.Lectures)
                .HasForeignKey(l => l.CurrentLectorId);

            builder.HasOne(l => l.GroupSchedule)
                .WithMany(gs => gs.Lectures)
                .HasForeignKey(l => l.CurrentLectureId);
        }
    }
}