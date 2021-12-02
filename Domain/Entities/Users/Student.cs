using ClassJournals.Domain.Entities.CoursesAndGroups;

namespace ClassJournals.Domain.Entities.Users
{
    public class Student : UserBase
    {
        public int StudentId { get; set; }

        public UserRoles Role { get; set; }

        public bool Payed { get; set; }
        public int Rating { get; set; }

        public string Group { get; set; }
        public Group Groups { get; set; }
    }
}