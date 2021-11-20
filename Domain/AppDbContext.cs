using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ClassJournals.Domain.Entities;
using ClassJournals.Domain.Entities.CoursesAndGroups;
using ClassJournals.Domain.Entities.JoiningEntities;
using System.Reflection;

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

        public DbSet<GroupSchedule> GroupSchedules { get; set; }
        public DbSet<LectorsSchedule> LectorsSchedule { get; set; }

//--------------------Таблиці розкладів--------------------------------------

        public DbSet<GroupsLectures> StudentLectures { get; set; }
        public DbSet<LectorsLecture> LectorsLectures { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            {
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            }

            modelBuilder.Entity<Group>()
                .HasMany<Student>(g => g.Students)
                .WithOne(s => s.Groups)
                .HasForeignKey(s => s.CurrentGroupId)
                .OnDelete(DeleteBehavior.Cascade);


//--------------------Викладач і лекції----------------------------------------

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

            modelBuilder.Entity<GroupsLectures>().HasKey(sl => new { sl.GroupId, sl.LectureId });

            modelBuilder.Entity<GroupsLectures>()
                .HasOne<Group>(gl => gl.Group)
                .WithMany(g => g.GroupsLectures)
                .HasForeignKey(sl => sl.GroupId);

            modelBuilder.Entity<GroupsLectures>()
                .HasOne<Lecture>(sl => sl.Lecture)
                .WithMany(l => l.GroupsLectures)
                .HasForeignKey(sl => sl.LectureId);

        }
    }
}
