using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassJournals.Domain.Entities;
using ClassJournals.Domain.Repositories.Abstract;

namespace ClassJournals.Domain.Repositories.EntityFramework
{
    public class EFStudentRepository : IStudentRepository
    {
        public void DeleteStudentItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentItemById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Student> GetStudentItems()
        {
            throw new NotImplementedException();
        }

        public void SaveStudentItem(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
