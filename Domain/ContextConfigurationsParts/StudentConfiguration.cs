using ClassJournals.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassJournals.Domain.ContextConfigurationsParts
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudentId);

            //builder.Property(s => s.StudentId)
            //    .HasColumnName("Student Id")
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

            builder.Ignore(s => s.FullName);

            builder.Property(s => s.Email).IsRequired();

            // Теоретично цей зв'язок має надати можливість
            // в бізнес-логіці обмежити доступ студенту до
            // редагування розкладів (read only)

            builder.HasOne(s => s.Role)
                .WithOne(r => r.Student)
                .HasForeignKey<UserRoles>(s => s.StudentId);

            // Нижче колонки в яких потрібно зробити обрахунок (якусь функцію) для обрахунку
            // рейтинга студента, який на пряму буде впивати на призначення стипендії...
            builder.Property(s => s.Payed).IsRequired();
            builder.Property(s => s.Rating);

            builder.Property(s => s.Group).HasColumnType("varchar")
                .HasMaxLength(5).HasColumnName("Група").IsRequired();

            builder.HasOne(s => s.Groups)
                .WithMany(g => g.Students)
                .HasPrincipalKey(s => s.Name);
        }
    }
}