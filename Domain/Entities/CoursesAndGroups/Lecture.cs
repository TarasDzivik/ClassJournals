using ClassJournals.Domain.Entities.JoiningEntities;
using ClassJournals.Domain.Entities.Schedules;
using System.Collections.Generic;
using ClassJournals.Domain.Entities.Users;

namespace ClassJournals.Domain.Entities.CoursesAndGroups
{
    public class Lecture
    {
        public int LectureId { get; set; }
        public string Name { get; set; }
        public long Hours { get; set; }
        public int Raiting { get; set; }

        public string CurrentLectorId { get; set; }
        public Lector Lectors { get; set; }
        public LectorsSchedule LectorsSchedule { get; set; }

        public int CurrentLectureId { get; internal set; }
        public GroupSchedule GroupSchedule { get; set; }

        public IList<GroupsLectures> GroupsLectures { get; set; }
        public IList<LectorsLecture> LectorsLecture { get; set; }
    }
}