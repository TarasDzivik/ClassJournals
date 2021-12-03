using System;
using System.Linq;
using ClassJournals.Domain.Entities.Users;

namespace ClassJournals.Domain.Repositories.Abstract
{
    public interface ILectorRepository
    {
        IQueryable<Lector> GetLectorItems();
        Lector GetLectorItemById(Guid id);
        void SaveLectorItem(Lector entity);
        void DeleteLectorItem(Guid id);
    }
}