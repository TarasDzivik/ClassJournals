using ClassJournals.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassJournals.Domain.ContextConfigurationsParts.AdminConfigurations
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<UserRoles>
    {
        public void Configure(EntityTypeBuilder<UserRoles> builder) // Необхідно розділити Айдентітірол і юзер і юзер рол
        {
            builder.HasData(new UserRoles
            {
                Id = 2147483647,
                Name = "admin",
                NormalizedName = "ADMIN"
            });
        }
    }
}