using Microsoft.EntityFrameworkCore;
using ClassJournals.Domain.Entities.CoursesAndGroups;
using ClassJournals.Domain.Repositories.Abstract;
using System.Linq;

namespace ClassJournals.Domain.Repositories.EntityFramework
{
    public class EFGroupeRepository : IGroupsRepository
    {
        private readonly AppDbContext context;
        public EFGroupeRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Group> GetGroupItems()
        {
            return context.Groups;
        }

        public Group GetGrouoItemById(int id)
        {
            return context.Groups.FirstOrDefault(g => g.GroupId == id);
        }

        public Group GetGroupItemByName(string Name)
        {
            return context.Groups.FirstOrDefault(g => g.Name == Name);
        }

        public void SaveGroupItem(Group entity)
        {
            if (entity.GroupId == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public void DeleteGroupItem(int id)
        {
            context.Groups.Remove(new Group() { GroupId = id });
            context.SaveChanges();
        }
    }
}