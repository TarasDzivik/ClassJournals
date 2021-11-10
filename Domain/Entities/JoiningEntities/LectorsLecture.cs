using ClassJournals.Domain.Entities.CoursesAndGroups;

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