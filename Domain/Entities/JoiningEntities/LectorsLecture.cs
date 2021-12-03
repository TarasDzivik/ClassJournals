using ClassJournals.Domain.Entities.CoursesAndGroups;
using ClassJournals.Domain.Entities.Users;

namespace ClassJournals.Domain.Entities.JoiningEntities
{
    public class LectorsLecture
    {
        public int LectorId { get; set; }
        public Lector Lector { get; set; }

        public int LectureId { get; set; }
        public Lecture Lecture { get; set; }
    }
}