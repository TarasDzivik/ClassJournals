using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassJournals.Domain.Entities;
using ClassJournals.Domain.Repositories.Abstract;

namespace ClassJournals.Domain.Repositories.EntityFramework
{
    public class EFLectorRepository : ILectorRepository
    {
        public void DeleteLectorItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Lector GetLectorItemById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Lector> GetLectorItems()
        {
            throw new NotImplementedException();
        }

        public void SaveLectorItem(Lector entity)
        {
            throw new NotImplementedException();
        }
    }
}
