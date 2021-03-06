using ClassJournals.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ClassJournals.Domain.Entities.Users;
using System;

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

        public Lector GetLectorItemById(Guid id)
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

        public void DeleteLectorItem(Guid id)
        {
            context.Lectors.Remove(new Lector() { LectorId = id });
            context.SaveChanges();
        }
    }
}