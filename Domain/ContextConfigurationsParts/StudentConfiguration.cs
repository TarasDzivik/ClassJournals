using ClassJournals.Domain.Entities;
using ClassJournals.Domain.Entities.CoursesAndGroups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassJournals.Domain.ContextConfigurationsParts
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(p => p.StudentId);

            builder.Property(p => p.FirstName).IsRequired()
                .HasMaxLength(30).HasColumnName("First name");

            builder.Property(p => p.LustName).IsRequired()
                .HasMaxLength(30).HasColumnName("Lust name");

            builder.Property(p => p.Email).IsRequired();

            builder.Property(p => p.Pass).IsRequired();

            // Поки що мушу почитати про using Microsoft.AspNetCore.Identity;
            // а то не тямлю які там поля для ідентифікації користувача,
            // тому рішив поки поля емейлів і т.д. не прописувати.

            builder.HasOne<Group>(s => s.Groups)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.CurrentGroupId);
        }
    }
}