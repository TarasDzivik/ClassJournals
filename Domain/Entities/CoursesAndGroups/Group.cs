using System.Collections.Generic;

namespace ClassJournals.Domain.Entities.CoursesAndGroups
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; } // one-to-many (один клас містить багато студентів)
        public Course Course { get; set; }
    }
}