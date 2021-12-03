using ClassJournals.Domain.Entities.CoursesAndGroups;
using System;

namespace ClassJournals.Domain.Entities.Users
{
    public class Student : UserBase
    {
        public Guid StudentId { get; set; }

        // Чи ця властивість і та що нижче
        // (public Group Groups) не являється дублюванням?
        // Чи не викличе воно концліктів і дублювань з CurrentGroupId?  
        public string Group { get; set; }
        public bool Payed { get; set; }
        public int Rating { get; set; }

        public int CurrentGroupId { get; set; }
        public Group Groups { get; set; }
        /* для уникнення циклічної залежності, студенти мають
           пов'язуватись із розкладом (GroupSchedule) через Group,
           Group в свою чергу прив'язана до Cource. */
    }
}