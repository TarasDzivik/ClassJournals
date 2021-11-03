using ClassJournals.Domain.Entities.CoursesAndGrades;
using ClassJournals.Domain.Entities.JoiningEntities;
using ClassJournals.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassJournals.Domain.Entities
{
    public class Lector : UserBase
    {
        public int LectorId { get; set; }
        // настройки ключів
        public int CurrentLectureId { get; set; }


        // Теоретично Викладач має мати в доступі всі нижче перечислені таблички в доступі many-to-many
        // треба уточнити чи в інтернетах чи можна в одному класі об'єднати більше ніж 2 таблички (юзаю EF 3.1 )?
        public ICollection<Student> Students { get; set; }
        public ICollection<Lecture> Lectures { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public ICollection<Course> Courses { get; set; }

        public LectorsSchedule LectorsSchedule { get; set; }
        public IList<LectorsLecture> LectorsLecture { get; set; }



    }
}
