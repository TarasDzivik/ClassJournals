using ClassJournals.Domain.Entities.CoursesAndGroups;
using System.Collections.Generic;
using ClassJournals.Domain.Entities.Users;


namespace ClassJournals.Domain.Entities.Schedules
{
    public class LectorsSchedule
    {
        public int ScheduleId { get; set; }

        public ICollection<Lecture> Lectures { get; set; }

        public Lector Lectors { get; set; }
    }
}