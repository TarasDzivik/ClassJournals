using Microsoft.AspNetCore.Identity;

namespace ClassJournals.Domain.Entities.Users
{
    public class UserBase : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LustName { get; set; }
        public override string UserName => $"{FirstName}{LustName}";  // Ця змінна використовуватиметься як логін (без пробілу між іменами)
        public string FullName => $"{FirstName} {LustName}";          // Ця змінна буде використовуватись в таблиці (но це не точно)
    }
}