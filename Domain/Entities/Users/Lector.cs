using ClassJournals.Domain.Entities.CoursesAndGrades;
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
        // настройки ключів
        public int CurrentLectureId { get; set; }
        public Lecture Lecture { get; set; }

        public Grade Grade { get; set; }
        public Course Course { get; set; }

    }
}
