using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassJournals.Domain.ContextConfigurationsParts.AdminConfigurations
{
    public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
        {
            builder.HasData(new IdentityUserRole<int>
            {
                RoleId = 2147483647,
                UserId = 2147483646
            });
        }
    }
}
