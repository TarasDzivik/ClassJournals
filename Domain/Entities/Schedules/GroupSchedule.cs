using System.Collections.Generic;

namespace ClassJournals.Domain.Entities.CoursesAndGroups
{
    public class GroupSchedule
    {
        public int ScheduleId { get; set; }

        public ICollection<Lecture> Lecture { get; set; }

        public Group Groups { get; set; }
    }
}