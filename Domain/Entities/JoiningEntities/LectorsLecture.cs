using ClassJournals.Domain.Entities.CoursesAndGroups;
using ClassJournals.Domain.Entities.Users;
using System;

namespace ClassJournals.Domain.Entities.JoiningEntities
{
    public class LectorsLecture
    {
        public int LectorId { get; set; }
        public Lector Lectors { get; set; }

        public int LectureId { get; set; }
        public Lecture Lectures { get; set; }
    }
}