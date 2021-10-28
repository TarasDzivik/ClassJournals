using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassJournals.Domain.Entities;
using ClassJournals.Domain.Entities.CoursesAndGrades;
using ClassJournals.Domain.Entities.JoiningEntities;

namespace ClassJournals.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Student { get; set; }
        public DbSet<Lecture> Lecture { get; set; }
        public DbSet<Lector> Lector { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Grade> Grades { get; set; }

        public DbSet<StudentLectures> StudentLectures { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "t.dzivik@gmail.com",
                NormalizedEmail = "T.DZIVIK@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            // Проміжна таблиця в якій ми зв'язуємо айді юзера з його роллю на сайті (адмін)
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
            });

            modelBuilder.Entity<Student>()
                .HasOne<Grade>(s => s.Grades)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.CurrentGradeId);

            modelBuilder.Entity<Grade>()
                .HasMany<Student>(g => g.Students)
                .WithOne(s => s.Grades)
                .HasForeignKey(s => s.CurrentGradeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentLectures>().HasKey(sl => new { sl.StudentId, sl.LectureId });

            modelBuilder.Entity<StudentLectures>()
                .HasOne<Student>(sl => sl.Student)
                .WithMany(s => s.StudentLectures)
                .HasForeignKey(sl => sl.StudentId);

            modelBuilder.Entity<StudentLectures>()
                .HasOne<Lecture>(sl => sl.Lecture)
                .WithMany(l => l.StudentLectures)
                .HasForeignKey(sl => sl.LectureId);






        }






    }
}
