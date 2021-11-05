using ClassJournals.Domain.Entities.CoursesAndGrades;
using ClassJournals.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ClassJournals.Domain.Repositories.EntityFramework
{
    public class EFLectorsScheduleRepository : ILectorsScheduleRepository
    {
        private readonly AppDbContext context;
        public EFLectorsScheduleRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<LectorsSchedule> GetScheduleItems()
        {
            return context.LectorsSchedule;
        }

        public LectorsSchedule GetScheduleItemById(int id)
        {
            return context.LectorsSchedule.FirstOrDefault(ls => ls.ScheduleId == id);
        }
        
        public void SaveScheduleItem(LectorsSchedule entity)
        {
            if (entity.ScheduleId == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void DeleteScheduleItem(int id)
        {
            context.LectorsSchedule.Remove(new LectorsSchedule() { ScheduleId = id });
            context.SaveChanges();
        }
    }
}