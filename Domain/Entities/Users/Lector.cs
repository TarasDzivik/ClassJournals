using ClassJournals.Domain.Entities.Schedules;
using ClassJournals.Domain.Entities.CoursesAndGroups;
using ClassJournals.Domain.Entities.JoiningEntities;
using System.Collections.Generic;
using System;

namespace ClassJournals.Domain.Entities.Users
{
    public class Lector : UserBase
    { 
        public Guid LectorId { get; set; }
        
        // настройки ключів
        public int CurrentLectureId { get; set; }

        public ICollection<Lecture> Lectures { get; set; }
        public LectorsSchedule LectorsSchedule { get; set; }

        public IList<LectorsLecture> LectorsLecture { get; set; }

        // Lector має мати доступ до LectureId
        // теоретично через бізнес логікою, лектор матиме
        // можливість виставляти оцінки чи позначати відсутніх.
    }
}