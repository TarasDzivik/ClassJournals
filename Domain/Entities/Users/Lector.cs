using ClassJournals.Domain.Entities.Schedules;
using ClassJournals.Domain.Entities.CoursesAndGroups;
using ClassJournals.Domain.Entities.JoiningEntities;
using System.Collections.Generic;

namespace ClassJournals.Domain.Entities.Users
{
    public class Lector : UserBase
    { 
        public int LectorId { get; set; }
        
        public UserRoles Role { get; set; }

        public int CurrentLectureId { get; set; }

        public ICollection<Lecture> Lecture { get; set; }
        public LectorsSchedule LectorsSchedule { get; set; }

        public int CurrentLectorId { get; set; }
        public IList<LectorsLecture> LectorsLecture { get; set; }

        // Lector має мати доступ до LectureId
        // теоретично через бізнес логікою, лектор матиме
        // можливість виставляти оцінки чи позначати відсутніх.
    }
}