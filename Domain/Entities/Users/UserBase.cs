using System;

namespace ClassJournals.Domain.Entities.Users
{
    public class UserBase 
// чи наслiдуватись тут вiд якогось identity чи
// використовувати прямо тут поля пароля і емейл?
    {
        public string FirstName { get; set; }
        public string LustName { get; set; }
        public string FullName => $"{FirstName} {LustName}";
        public DateTime DateOfBirthday { get; set; }

        public string Email { get; set; }
        public string Pass { get; set; }
        public string RepeatPass { get; set; }
    }
}