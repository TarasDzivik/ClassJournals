using Microsoft.AspNetCore.Identity;

namespace ClassJournals.Domain.Entities.Users
{
    public class UserRoles : IdentityRole<int>
    {
        public int LectorId { get; set; }
        public Lector Lector { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}