using ClassJournals.Domain.Entities.CoursesAndGroups;
using System.Linq;

namespace ClassJournals.Domain.Repositories.Abstract
{
    public interface ILectorsScheduleRepository
    {
        IQueryable<LectorsSchedule> GetScheduleItems();
        LectorsSchedule GetScheduleItemById(int id);
        void SaveScheduleItem(LectorsSchedule entity);
        void DeleteScheduleItem(int id);
    }
}