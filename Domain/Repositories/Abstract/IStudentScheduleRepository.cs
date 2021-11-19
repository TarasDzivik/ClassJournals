using ClassJournals.Domain.Entities.CoursesAndGroups;
using System.Linq;

namespace ClassJournals.Domain.Repositories.Abstract
{
    public interface IStudentScheduleRepository
    {
        IQueryable<GroupSchedule> GetScheduleItems();
        GroupSchedule GetScheduleItemById(int id);
        void SaveScheduleItem(GroupSchedule entity);
        void DeleteScheduleItem(int id);
    }
}