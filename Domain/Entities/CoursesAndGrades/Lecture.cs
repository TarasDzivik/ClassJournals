using ClassJournals.Domain.Entities.CoursesAndGrades;
using ClassJournals.Domain.Entities.JoiningEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassJournals.Domain.Entities
{
    public class Lecture
    {
        public int LectureId { get; set; }
        public string Name { get; set; }
        public string Agenda { get; set; } // Можливо в майбутньому створю ще одну табличку з планами лекцый,
                                           // щоб можна було розділити теми по лекціямм (в ідеалі щоб, коли
                                           // позначав лекцію в розкладі, то воно автоматично розприділяло теми
                                           // лекцій по днях)?
        public double TotalHours { get; set; }

        public int CurrentLectorId { get; set; }
        public Lector Lectors { get; set; }


        public IList<LectorsLecture> LectorsLecture { get; set; }
        public IList<StudentLectures> StudentLectures { get; set; }

        public virtual Course Course  { get; set; } // вичитав у книзі C# 9 and .NET 5 Mark J.Price

        // що якщо позначити рілейшини як virtual то це доповнить
        // додати Lazy loading та інші фічі... А воно взагалі потрібно?
    }
}
