using ClassJournals.Domain.Entities.JoiningEntities;
using System.Collections.Generic;

namespace ClassJournals.Domain.Entities.CoursesAndGroups
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; } // one-to-many (один клас містить багато студентів)
        public Course Course { get; set; }                 // one course to many Groups
        public GroupSchedule GroupSchedule { get; set; }   // 1 розклад = 1 група
        
        public IList<GroupsLectures> GroupsLectures { get; set; }
    }
}