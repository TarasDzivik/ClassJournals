using System.Collections.Generic;

namespace ClassJournals.Domain.Entities.CoursesAndGroups
{
    public class LectorsSchedule
    {
        public int ScheduleId { get; set; }
        
        public Lector Lector { get; set; } // 1 розклад = 1 викладач

        public ICollection<Lecture> Lectures { get; set; }

    }
}