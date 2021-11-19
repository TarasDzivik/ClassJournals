using ClassJournals.Domain.Entities.CoursesAndGroups;
using ClassJournals.Domain.Entities.JoiningEntities;
using ClassJournals.Domain.Entities.Users;
using System.Collections.Generic;

namespace ClassJournals.Domain.Entities
{
    public class Lector : UserBase
    {
        public int LectorId { get; set; }
        // настройки ключів
        public int CurrentLectureId { get; set; }

        public ICollection<Lecture> Lectures { get; set; }

        public LectorsSchedule LectorsSchedule { get; set; }
        public IList<LectorsLecture> LectorsLecture { get; set; }

        // Lector має мати доступ до LectureId
        // теоретично через бізнес логіку по цьому шляху, лектор матиме
        // можливість виставляти оцінки чи позначати відсутніх 
    }
}