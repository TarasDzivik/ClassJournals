using System.Linq;
using ClassJournals.Domain.Entities;

namespace ClassJournals.Domain.Repositories.Abstract
{
    public interface ILectorRepository
    {
        IQueryable<Lector> GetLectorItems();
        Lector GetLectorItemById(int id);
        void SaveLectorItem(Lector entity);
        void DeleteLectorItem(int id);
    }
}