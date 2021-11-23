using ClassJournals.Domain.Entities.JoiningEntities;
using System.Collections.Generic;

namespace ClassJournals.Domain.Entities.CoursesAndGroups
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public long TotalHours { get; set; }

        public ICollection<Group> Group { get; set; }

    }
}