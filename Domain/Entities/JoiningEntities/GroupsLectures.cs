using ClassJournals.Domain.Entities.CoursesAndGroups;

namespace ClassJournals.Domain.Entities.JoiningEntities
{
    public class GroupsLectures
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int LectureId { get; set; }
        public Lecture Lecture { get; set; }
    }
}