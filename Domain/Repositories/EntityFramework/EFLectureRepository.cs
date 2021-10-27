using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassJournals.Domain.Entities;
using ClassJournals.Domain.Repositories.Abstract;

namespace ClassJournals.Domain.Repositories.EntityFramework
{
    public class EFLectureRepository : ILectureRepository
    {
        public void DeleteLectureItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Lecture GetLectureItemById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Lecture> GetLectureItems()
        {
            throw new NotImplementedException();
        }

        public void SaveLectureItem(Lecture entity)
        {
            throw new NotImplementedException();
        }
    }
}
