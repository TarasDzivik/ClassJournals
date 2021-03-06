using ClassJournals.Domain.Entities.CoursesAndGroups;
using System.Collections.Generic;

namespace ClassJournals.Domain.Entities.Schedules
{ 
    public class GroupSchedule
    {
        public int ScheduleId { get; set; }
        
        /* Сюди необхідно добавити якісь проперті, які розміщатимуть які
           міститимуть в собі дату і номер лекції (1,2,3,4 і т.д.) */


        public ICollection<Lecture> Lectures { get; set; }
        public Group Group { get; set; }
    }
}