using ClassJournals.Domain.Entities.CoursesAndGroups;
using System.Linq;
namespace ClassJournals.Domain.Repositories.Abstract
{
    public interface IGroupsRepository
    {
        IQueryable<Group> GetGroupItems();
        Group GetGrouoItemById(int id);
        Group GetGroupItemByName(string Name);
        void SaveGroupItem(Group entity);
        void DeleteGroupItem(int id);
    }
}