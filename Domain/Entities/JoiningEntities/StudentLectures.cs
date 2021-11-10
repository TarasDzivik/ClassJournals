using ClassJournals.Domain.Entities.CoursesAndGroups;

namespace ClassJournals.Domain.Entities.JoiningEntities
{
    public class StudentLectures
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int LectureId { get; set; }
        public Lecture Lecture { get; set; }
    }
}