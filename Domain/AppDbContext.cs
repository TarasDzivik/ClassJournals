using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ClassJournals.Domain.Entities.CoursesAndGroups;
using ClassJournals.Domain.Entities.Schedules;
using ClassJournals.Domain.Entities.JoiningEntities;
using System.Reflection;
using ClassJournals.Domain.Entities.Users;

namespace ClassJournals.Domain
{
    public class AppDbContext : IdentityDbContext<UserBase, UserRoles, int>
    {
      
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

//--------------------Основні таблиці----------------------------------------

        public DbSet<Student> Student { get; set; }
        public DbSet<Lecture> Lecture { get; set; }
        public DbSet<Lector> Lectors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }

//--------------------Проміжні таблиці---------------------------------------

        public DbSet<GroupsLectures> GroupsLectures { get; set; }
        public DbSet<LectorsLecture> LectorsLectures { get; set; }

//--------------------Таблиці розкладів--------------------------------------

        public DbSet<GroupSchedule> GroupSchedule { get; set; }
        public DbSet<LectorsSchedule> LectorsSchedule { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            {
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            }
        }
    }
}