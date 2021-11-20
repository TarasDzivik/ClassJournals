using ClassJournals.Domain.Entities;
using ClassJournals.Domain.Entities.CoursesAndGroups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ClassJournals.Domain.ContextConfigurationsParts
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudentId);

            builder.Property(s => s.FirstName).IsRequired()
                .HasMaxLength(15).HasColumnType("varchar")
                .HasColumnName("First name");

            builder.Property(s => s.LustName).IsRequired()
                .HasMaxLength(15).HasColumnType("varchar")  // чи обов'язково прописувати
                .HasColumnName("Lust name");                //  .HasColumnType("varchar") ???

            builder.Ignore(s => s.FullName); // Рішив спробувати, створити рядок повного імені,
                                             // але разом з тим не включати йогов основну таблицю.
                                             // Логіка така, що FullName повинен виводитись в
                                             // журналі цілої групи для еконмії колонок.
            
            builder.Property(s => s.Email).IsRequired();
            builder.Property(s => s.Pass).IsRequired();

            // треба прописати можливість обрахунку рейтингу студента, чи він підлягає стипендії...
            builder.Property(s => s.Payed).IsRequired();
            builder.HasQueryFilter(s => EF.Property<bool>(s, "Payed") == true);
            //var student = context.Student.ToList(); // то десь в бізнес логіку запхати

            // Поки що мушу почитати про using Microsoft.AspNetCore.Identity;
            // а то не тямлю які там поля для ідентифікації користувача,
            // тому рішив поки поля емейлів і т.д. не прописувати.

            builder.HasOne<Group>(s => s.Groups)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.CurrentGroupId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}