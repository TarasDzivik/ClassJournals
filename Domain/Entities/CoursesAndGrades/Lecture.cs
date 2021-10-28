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
        public string Agenda { get; set; } // план лекцій в стрінг чи краще якийсь List<string> щоб можна було розділити теми по лекціям?
        public double TotalHours { get; set; }


        public IList<StudentLectures> StudentLectures { get; set; }
        public virtual Course Course  { get; set; } // вичитав у книзі C# 9 and .NET 5 Mark J.Price
                                                    // що якщо позначити рілейшини як virtual то це доповнить
                                                    // додати Lazy loading та інші фічі... А воно взагалі потрібно?
    }
}
