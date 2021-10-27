using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClassJournals.Domain.Entities
{
    public abstract class UserBase : IdentityDbContext<IdentityUser> // Як добавити ідентифікацію з допомогою Identity сервісів
                                                                     // чи окремо прописувати змінні для логіна пароля і т.д.?
    {
        protected UserBase() => DateAdded = DateTime.UtcNow;
        public DateTime DateAdded { get; set; }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LustName { get; set; }
        public string Status { get; set; }
        public string Grade { get; set; }
        public string Course { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; }

    }
}
