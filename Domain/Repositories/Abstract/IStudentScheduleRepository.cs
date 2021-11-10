using ClassJournals.Domain.Entities.CoursesAndGroups;
using System.Linq;

namespace ClassJournals.Domain.Repositories.Abstract
{
    public interface IStudentScheduleRepository
    {
        IQueryable<StudentsSchedule> GetScheduleItems();
        StudentsSchedule GetScheduleItemById(int id);
        void SaveScheduleItem(StudentsSchedule entity);
        void DeleteScheduleItem(int id);
    }
}