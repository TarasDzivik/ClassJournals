using System;
using System.Linq;
using ClassJournals.Domain.Entities.CoursesAndGroups;
using ClassJournals.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ClassJournals.Domain.Repositories.EntityFramework
{
    public class EFLectureRepository : ILectureRepository
    {
        private readonly AppDbContext context;
        public EFLectureRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Lecture> GetLectureItems()
        {
            return context.Lecture;
        }

        public Lecture GetLectureItemById(int id)
        {
            return context.Lecture.FirstOrDefault(l => l.LectureId == id);
        }

        public void SaveLectureItem(Lecture entity)
        {
            if (entity.LectureId == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void DeleteLectureItem(int id)
        {
            context.Lecture.Remove(new Lecture() { LectureId = id });
            context.SaveChanges();
        }
    }
}