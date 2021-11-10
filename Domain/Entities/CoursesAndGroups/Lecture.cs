using ClassJournals.Domain.Entities.JoiningEntities;
using System.Collections.Generic;

namespace ClassJournals.Domain.Entities.CoursesAndGroups
{
    public class Lecture
    {
        public int LectureId { get; set; }
        public string Name { get; set; }
        public string Agenda { get; set; } // Можливо в майбутньому створю ще одну табличку з планами лекцый,
                                           // щоб можна було розділити теми по лекціямм (в ідеалі щоб, коли
                                           // позначав лекцію в розкладі, то воно автоматично розприділяло теми
                                           // лекцій по днях)?
        public double Hours { get; set; }
        public int Raiting { get; set; }

        public int CurrentLectorId { get; set; }
        public Lector Lectors { get; set; }


        public IList<LectorsLecture> LectorsLecture { get; set; }
        public IList<StudentLectures> StudentLectures { get; set; }
        public IList<CoursesLectures> CoursesLectures { get; set; }
        public ICollection<Course> Courses { get; set; } // Course може мати багато Lectures так і навпаки (many-to-many)

    }
}