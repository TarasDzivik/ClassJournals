using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassJournals.Domain.Entities.Users
{
    public class UserBase // чи наслiдуватись тут вiд якогось identity чи використовувати прямо тут поля пароля і емейл?
    {
        protected UserBase() => DateAdded = DateTime.UtcNow;
        public DateTime DateAdded { get; set; }

        public string FirstName { get; set; }
        public string LustName { get; set; }
        public DateTime DateOfBirthday { get; set; }

        public string Email { get; set; }
        public string Pass { get; set; }
        public string RepeatPass { get; set; }
    }
}
