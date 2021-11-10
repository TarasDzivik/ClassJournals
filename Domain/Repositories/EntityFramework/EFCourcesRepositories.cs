using ClassJournals.Domain.Entities.CoursesAndGroups;
using ClassJournals.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ClassJournals.Domain.Repositories.EntityFramework
{
    public class EFCourcesRepositories : ICourcesRepository
    {
        private readonly AppDbContext context;
        public EFCourcesRepositories(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Course> GetCourseItem()
        {
            return context.Courses;
        }

        public Course GetCourseItemById(int id)
        {
            return context.Courses.FirstOrDefault(c => c.CourseId == id);
        }

        public void SaveCourseItem(Course entity)
        {
            if (entity.CourseId == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public void DeleteCourceItem(int id)
        {
            context.Courses.Remove(new Course() { CourseId = id});
            context.SaveChanges();
        }
    }
}