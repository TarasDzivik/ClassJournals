using System.Linq;
using ClassJournals.Domain.Entities.Users;

namespace ClassJournals.Domain.Repositories.Abstract
{
    public interface IStudentRepository
    {
        IQueryable<Student> GetStudentItems();  // Вибрати всх Студентів.
        Student GetStudentItemById(int id);     // Вибрати Студента по Ідентифікатору.
        void SaveStudentItem(Student entity);   // Обновити або зберегти Студента.
        void DeleteStudentItem(int id);         // Видалити Студента.
    }
}