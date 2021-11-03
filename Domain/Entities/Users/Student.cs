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
    public class Student : UserBase
    {
        public int StudentId { get; set; }

        public string Grade { get; set; }
        public string Course { get; set; }

        public bool Payed { get; set; }
        public int Rating { get; set; }

        public int CurrentGradeId { get; set; }
        public Grade Grades { get; set; }

        public StudentsSchedule StudentSchedule { get; set; }
        public IList<StudentLectures> StudentLectures { get; set; }
    }
}
