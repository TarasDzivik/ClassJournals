using ClassJournals.Domain.Entities.CoursesAndGroups;

namespace ClassJournals.Domain.Entities.JoiningEntities
{
    public class CoursesLectures
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int LectureId { get; set; }
        public Lecture Lecture { get; set; }
    }
}