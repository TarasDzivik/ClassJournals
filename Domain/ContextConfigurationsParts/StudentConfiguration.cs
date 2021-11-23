using ClassJournals.Domain.Entities.Users;
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
                .HasMaxLength(15).HasColumnType("varchar")
                .HasColumnName("Lust name");

            builder.Property(s => s.UserName).IsRequired()
                .HasColumnName("Login");
            builder.Property(s => s.Email).IsRequired();

            builder.Property(s => s.Group).HasColumnType("varchar")     // Надіюсь не створить 2 колонки
                .HasMaxLength(5).HasColumnName("Група").IsRequired();   // Property(s => s.Group)
            builder.HasOne(s => s.Groups)    // <------------------і навігаційні властивості?
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.CurrentGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            // Нижче колонки в яких потрібно зробити обрахунок (якусь функцію) для обрахунку
            // рейтинга студента, який на пряму буде впивати на призначення стипендії...
            builder.Property(s => s.Rating);
            builder.Property(s => s.Payed).IsRequired();
            builder.HasQueryFilter(s => EF.Property<bool>(s, "Payed") == true);
        }
    }
}