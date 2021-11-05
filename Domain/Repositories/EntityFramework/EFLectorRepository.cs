using ClassJournals.Domain.Repositories.Abstract;
using ClassJournals.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ClassJournals.Domain.Repositories.EntityFramework
{
    public class EFLectorRepository : ILectorRepository
    {
        private readonly AppDbContext context;
        public EFLectorRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Lector> GetLectorItems()
        {
            return context.Lectors;
        }

        public Lector GetLectorItemById(int id)
        {
            return context.Lectors.FirstOrDefault(l => l.LectorId == id);
        }

        public void SaveLectorItem(Lector entity)
        {
            if (entity.LectorId == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void DeleteLectorItem(int id)
        {
            context.Lectors.Remove(new Lector() { LectorId = id });
            context.SaveChanges();
        }
    }
}