//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace ClassJournals.Domain.ContextConfigurationsParts
//{
//    public class AdminIdentityConfiguration : IEntityTypeConfiguration<IdentityRole>
//    {
//        public void Configure(EntityTypeBuilder<IdentityRole> builder) // Необхідно розділити Айдентітірол і юзер і юзер рол
//        {
//            builder.HasData(new IdentityRole
//            {
//                Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
//                Name = "admin",
//                NormalizedName = "ADMIN"
//            });

//            builder.HasData(new IdentityUser
//            {
//                Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
//                UserName = "admin",
//                NormalizedUserName = "ADMIN",
//                Email = "t.dzivik@gmail.com",
//                NormalizedEmail = "T.DZIVIK@GMAIL.COM",
//                EmailConfirmed = true,
//                PasswordHash = new PasswordHasher<IdentityUser>()
//                .HashPassword(null, "superpassword"),
//                SecurityStamp = string.Empty,
//                AccessFailedCount = 3
//            });

//            builder.HasData(new IdentityUserRole<string>
//            {
//                RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
//                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
//            });
//        }
//    }
//}