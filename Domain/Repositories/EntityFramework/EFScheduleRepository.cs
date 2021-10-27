using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassJournals.Domain.Entities;
using ClassJournals.Domain.Repositories.Abstract;

namespace ClassJournals.Domain.Repositories.EntityFramework
{
    public class EFScheduleRepository : IScheduleRepository
    {
        public void DeleteScheduleItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Schedule GetScheduleItemById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Schedule> GetScheduleItems()
        {
            throw new NotImplementedException();
        }

        public void SaveScheduleItem(Schedule entity)
        {
            throw new NotImplementedException();
        }
    }
}
