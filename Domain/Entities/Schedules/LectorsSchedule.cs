using System.Collections.Generic;

namespace ClassJournals.Domain.Entities.CoursesAndGrades
{
    public class LectorsSchedule
    {
        public int ScheduleId { get; set; }

        public ICollection<Lector> Lectors { get; set; }

    }
}
