using ClassJournals.Domain.Entities.CoursesAndGrades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassJournals.Domain.Entities
{
    public class Student : UserBase
    {

        public string password { get; set; }
        public string repeatPassword { get; set; }

        private DateTime dateOfBirthday { get; set; }

        public int CurrentGradeId { get; set; }
        public Grade Grades { get; set; }
    }
}
