using ClassJournals.Domain.Entities.CoursesAndGroups;
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

        public ICollection<Student> Students { get; set; }
        public ICollection<Lecture> Lectures { get; set; }
        public ICollection<Group> Grades { get; set; }
        public ICollection<Course> Courses { get; set; }

        public LectorsSchedule LectorsSchedule { get; set; }
        public IList<LectorsLecture> LectorsLecture { get; set; }



    }
}
