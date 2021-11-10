using ClassJournals.Domain.Entities.CoursesAndGroups;
using System.Linq;

namespace ClassJournals.Domain.Repositories.Abstract
{
    public interface ICourcesRepository
    {
        IQueryable<Course> GetCourseItem();
        Course GetCourseItemById(int id);
        void SaveCourseItem(Course entity);
        void DeleteCourceItem(int id);
    }
}