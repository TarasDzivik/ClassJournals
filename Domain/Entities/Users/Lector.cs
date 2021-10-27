using ClassJournals.Domain.Entities.CoursesAndGrades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassJournals.Domain.Entities
{
    public class Lector : UserBase
    {
        

        public int currentLectureId { get; set; }
        public Lecture Lecture { get; set; }
    }
}
