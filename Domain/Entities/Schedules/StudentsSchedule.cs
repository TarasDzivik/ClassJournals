using System.Collections.Generic;

namespace ClassJournals.Domain.Entities.CoursesAndGrades
{
    public class StudentsSchedule
    {
        public int ScheduleId { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
