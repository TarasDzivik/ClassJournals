using System.Collections.Generic;

namespace ClassJournals.Domain.Entities.CoursesAndGroups
{
    public class Course
    {
        // ПИТАННЯ Мені юзати DataAnotation для визначення вимог полыв по типу [REQUAIRED]
        // Чи десь в AppDbContext якось прописати до полей IsRequaired()...
        // Чи це прямо в цьому класі якось прописувати використовуючи FluentAPI?

        public int CourseId { get; set; }
        public string Name { get; set; }
        public int Scores { get; set; }
        public string Agenda { get; set; }
        public double TotalHours { get; set; }
        
        public ICollection<Lecture>  Lectures { get; set; }
        public ICollection<Group> Grades { get; set; }
        public ICollection<Student> Students { get; set; }

    }
}