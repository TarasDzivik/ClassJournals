using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassJournals.Domain.Entities.CoursesAndGrades
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; } // one-to-many (один клас містить багато студентів)
        public Course Course { get; set; }
    }
}
