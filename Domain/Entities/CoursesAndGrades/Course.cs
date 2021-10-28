using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassJournals.Domain.Entities.CoursesAndGrades
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; } // чи норм назви полів по типу Name чи в данному випадку краще - CourseName???
        public int Scores { get; set; }
        public string Agenda { get; set; }
        public double Hours { get; set; }

        public ICollection<Lecture>  Lectures { get; set; }

    }
}
