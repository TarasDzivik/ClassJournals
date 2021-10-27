using System;
using System.Linq;
using ClassJournals.Domain.Entities;

namespace ClassJournals.Domain.Repositories.Abstract
{
    public interface ILectureRepository
    {
        IQueryable<Lecture> GetLectureItems();
        Lecture GetLectureItemById(Guid id);
        void SaveLectureItem(Lecture entity);
        void DeleteLectureItem(Guid id);
    }
}
