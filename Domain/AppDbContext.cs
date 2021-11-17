using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ClassJournals.Domain.Entities;
using ClassJournals.Domain.Entities.CoursesAndGroups;
using ClassJournals.Domain.Entities.JoiningEntities;
using ClassJournals.Domain.ContextConfigurationsParts;
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

            { // SCHEMA хз що це, буду читати
                modelBuilder.HasDefaultSchema("MyCustomSchema");
            }

            // по ідеї цей рядок повинен сам реєструвати нові типи конфігурацій (new ApplyConfiguration) при додаванні нових сутьностей в проект... Поки що ще читаю про це.
            {
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            }

            modelBuilder.ApplyConfiguration(new AdminIdentityConfiguration());

            // Проміжна таблиця в якій ми зв'язуємо айді юзера з його роллю на сайті (адмін)
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
            });
            // ПИТАННЯ - Не зрозумів як інтегрувати IdentityUserRole<string> в AdminIdentityConfiguration() ?

            // Нижче настройка зв'язків між таблицями

            //--------------------Клас і студенти----------------------------------------
            modelBuilder.ApplyConfiguration(new StudentConfiguration());

            //modelBuilder.Entity<Student>()
            //    .HasOne<Group>(s => s.Groups)
            //    .WithMany(g => g.Students)
            //    .HasForeignKey(s => s.CurrentGroupId);
            //  Я так розумію, що цей блок коду лишній,
            //  так як я в написав подібне уже в StudentConfiguration.cs ??????????

            modelBuilder.Entity<Group>()
                .HasMany<Student>(g => g.Students)
                .WithOne(s => s.Groups)
                .HasForeignKey(s => s.CurrentGroupId)
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
