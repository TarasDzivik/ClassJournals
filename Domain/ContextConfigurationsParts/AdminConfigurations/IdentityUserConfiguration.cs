using ClassJournals.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassJournals.Domain.ContextConfigurationsParts.AdminConfigurations
{
    public class IdentityUserConfiguration : IEntityTypeConfiguration<UserBase>
    {
        public void Configure(EntityTypeBuilder<UserBase> builder)
        {
            builder.HasData(new UserBase
            {
                Id = 2147483646,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "t.dzivik@gmail.com",
                NormalizedEmail = "T.DZIVIK@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty,
                AccessFailedCount = 3
            });
        }
    }
}
