using System.Collections.Generic;

namespace ClassJournals.Domain.Entities.CoursesAndGroups
{
    public class StudentsSchedule
    {
        public int ScheduleId { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
