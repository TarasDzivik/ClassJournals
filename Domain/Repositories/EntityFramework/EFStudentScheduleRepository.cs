using ClassJournals.Domain.Entities.CoursesAndGroups;
using ClassJournals.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ClassJournals.Domain.Repositories.EntityFramework
{
    public class EFStudentScheduleRepository : IStudentScheduleRepository
    {
        private readonly AppDbContext context;
        public EFStudentScheduleRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<StudentsSchedule> GetScheduleItems()
        {
            return context.StudentsSchedule;
        }

        public StudentsSchedule GetScheduleItemById(int id)
        {
            return context.StudentsSchedule.FirstOrDefault(sl => sl.ScheduleId == id);
        }

        public void SaveScheduleItem(StudentsSchedule entity)
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
            context.StudentsSchedule.Remove(new StudentsSchedule() { ScheduleId = id });
            context.SaveChanges();
        }
    }
}