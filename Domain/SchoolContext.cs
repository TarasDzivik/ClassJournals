using ClassJournals.Domain.Entities.CoursesAndGrades;
using ClassJournals.Domain.Entities.JoiningEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassJournals.Domain.Entities
{
    public class SchoolContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne<Grade>(s => s.Grades)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.CurrentGradeId);




            // чи потрібно в цьому класі налаштувати каскадне видалення чи для цього необхідно створити інший клас???

            //modelBuilder.Entity<Grade>()
            //    .HasMany<Student>(g => g.Students)
            //    .WithOne(s => s.Grade)
            //    .HasForeignKey(s => s.CurrentGradeId);

            //modelBuilder.Entity<Grade>()
            //    .HasMany<Student>(g => g.Students)
            //    .WithOne(s => s.Grade)
            //    .HasForeignKey(s => s.CurrentGradeId)
            //    .OnDelete(DeleteBehavior.Cascade);

            // Об'єднана таблиця з двома ключами для реалізації many-to-many
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


       

        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lector> Lectors { get; set; }
        public DbSet<StudentLectures> StudentLectures { get; set; }
    }
}
