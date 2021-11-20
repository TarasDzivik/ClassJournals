using ClassJournals.Domain.Entities.CoursesAndGroups;
using ClassJournals.Domain.Entities.Users;

namespace ClassJournals.Domain.Entities
{
    public class Student : UserBase
    {
        public int StudentId { get; set; }

        public string Grade { get; set; }   // Чи потрібно це поле робити як навігаційне?
        public string Course { get; set; }  // Чи не викличе воно концліктів і дублювань з CurrentGroupId?  

        public bool Payed { get; set; }
        public int Rating { get; set; }

        public int CurrentGroupId { get; set; }
        public Group Groups { get; set; }

        public GroupSchedule GroupSchedule { get; set; }

        /* для уникнення циклічної залежності, студенти мають
           пов'язуватись із розкладом (GroupSchedule) через Group,
           Group в свою чергу прив'язана до Cource. */
    }
}