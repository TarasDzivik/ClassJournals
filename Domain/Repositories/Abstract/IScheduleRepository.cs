using System;
using System.Linq;
using ClassJournals.Domain.Entities;

namespace ClassJournals.Domain.Repositories.Abstract
{
    public interface IScheduleRepository
    {
        IQueryable<Schedule> GetScheduleItems();
        Schedule GetScheduleItemById(Guid id);
        void SaveScheduleItem(Schedule entity);
        void DeleteScheduleItem(Guid id);
    }
}
