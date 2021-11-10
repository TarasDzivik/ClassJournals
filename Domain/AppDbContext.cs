using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassJournals.Domain.Entities;
using ClassJournals.Domain.Entities.CoursesAndGroups;
using ClassJournals.Domain.Entities.JoiningEntities;

namespace ClassJournals.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

//--------------------Основні таблиці----------------------------------------

        public DbSet<Student> Student { get; set; }
        public DbSet<Lecture> Lecture { get; set; }
        public DbSet<Lector> Lectors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }

        //--------------------Проміжні таблиці---------------------------------------

        public DbSet<StudentsSchedule> StudentsSchedule { get; set; }
        public DbSet<LectorsSchedule> LectorsSchedule { get; set; }
        public DbSet<CoursesLectures> CoursesLectures { get; set; }

//--------------------Таблиці розкладів--------------------------------------

        public DbSet<StudentLectures> StudentLectures { get; set; }
        public DbSet<LectorsLecture> LectorsLectures { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
// ------------------Налаштування ідентифікації Адміна-----------------------

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


            // Нижче настройка зв'язків між таблицями

//--------------------Клас і студенти----------------------------------------

            modelBuilder.Entity<Student>()
                .HasOne<Group>(s => s.Grades)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.CurrentGradeId);

            modelBuilder.Entity<Group>()
                .HasMany<Student>(g => g.Students)
                .WithOne(s => s.Grades)
                .HasForeignKey(s => s.CurrentGradeId)
                .OnDelete(DeleteBehavior.Cascade);


//--------------------Викладач і лекції----------------------------------------

            modelBuilder.Entity<Lecture>()
                .HasOne<Lector>(lu => lu.Lectors)
                .WithMany(lo => lo.Lectures)
                .HasForeignKey(lu => lu.CurrentLectorId);

            modelBuilder.Entity<Lecture>()
                .HasOne<Lector>(lu => lu.Lectors)
                .WithMany(lo => lo.Lectures)
                .HasForeignKey(lu => lu.CurrentLectorId)
                .OnDelete(DeleteBehavior.Cascade);


//--------------------Налаштування проміжних таблиць--------------------------------------

            modelBuilder.Entity<LectorsLecture>().HasKey(Ll => new { Ll.LectorId, Ll.LectureId });

            modelBuilder.Entity<LectorsLecture>()
                .HasOne<Lector>(Ll => Ll.Lector)
                .WithMany(l => l.LectorsLecture)
                .HasForeignKey(Ll => Ll.LectorId);

            modelBuilder.Entity<LectorsLecture>()
                .HasOne<Lecture>(Ll => Ll.Lecture)
                .WithMany(L => L.LectorsLecture)
                .HasForeignKey(Ll => Ll.LectureId);

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
