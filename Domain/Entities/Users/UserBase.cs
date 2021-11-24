using Microsoft.AspNetCore.Identity;

namespace ClassJournals.Domain.Entities.Users
{
    public class UserBase : IdentityUser
    // чи наслiдуватись тут вiд якогось identity чи
    // використовувати прямо тут поля пароля і емейл?
    {
        public string FirstName { get; set; }
        public string LustName { get; set; }
        public override string UserName => $"{FirstName}{LustName}";  // Wя змінна використовуватиметься як логін (без пробілу між іменами)
        public string FullName => $"{FirstName} {LustName}";          // Ця змінна буде використовуватись в таблиці (но це не точно)
    }
}