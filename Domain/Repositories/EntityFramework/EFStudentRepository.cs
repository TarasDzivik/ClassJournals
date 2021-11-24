using System.Linq;
using Microsoft.EntityFrameworkCore;
using ClassJournals.Domain.Entities.Users;
using ClassJournals.Domain.Repositories.Abstract;

namespace ClassJournals.Domain.Repositories.EntityFramework
{
    public class EFStudentRepository : IStudentRepository
    {
        private readonly AppDbContext context;
        public EFStudentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Student> GetStudentItems()
        {
            return context.Student;
        }

        public Student GetStudentItemById(int id)
        {
            return context.Student.FirstOrDefault(s => s.StudentId == id); 
        }

        public void SaveStudentItem(Student entity)
        {
            if (entity.StudentId == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void DeleteStudentItem(int id)
        {
            context.Student.Remove(new Student() { StudentId = id });
            context.SaveChanges();
        }
    }
}