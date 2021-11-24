using ClassJournals.Domain.Entities.JoiningEntities;
using System.Collections.Generic;
using ClassJournals.Domain.Entities.Users;
using ClassJournals.Domain.Entities.Schedules;

namespace ClassJournals.Domain.Entities.CoursesAndGroups
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }
        public Course Course { get; set; }
        public int CurrentCourseId { get; internal set; }  // VS сама згенерувала інтернал (треба уточнити) чи 
                                                           // правильно налаштований доступ і чи не треба до
                                                           // інших методів теж так само налаштувати????

        public GroupSchedule GroupSchedule { get; set; }       
        public IList<GroupsLectures> GroupsLectures { get; set; }
       
    }
}