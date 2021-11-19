using ClassJournals.Domain.Entities.CoursesAndGroups;
using System.Linq;
namespace ClassJournals.Domain.Repositories.Abstract
{
    public interface IGroupsRepository
    {
        IQueryable<Group> GetGroupItems();
        Group GetGroupItemById(int id);
        void SaveGroupItem(Group entity);
        void DeleteGroupItem(int id);
    }
}