using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ordinanceMulti_tenantCore.domain.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ordinanceMulti_tenantCore.persistence
{
    public class Ordinance_SharedDbInitializer
    {
        public static void Initialize(ModelBuilder modelBuilder)
        {
            new Ordinance_SharedDbInitializer().SeedData(modelBuilder);
        }

        public void SeedData(ModelBuilder modelBuilder)
        {
            SeedUsers(modelBuilder);
            SeedUserRoles(modelBuilder);
            SeedRoles(modelBuilder);
        }

        private void SeedUsers(ModelBuilder modelBuilder)
        {
            var user = new User
            {
                Id = "9A6EA564-7238-5CD6-BD64-DA142DD43FF5",
                Email = "muhamedbrajshori@hotmail.com",
                EmailConfirmed = true,
                NormalizedEmail = "muhamedbrajshori@hotmail.com",
                FirstName = "Muhamed",
                LastName = "Brajshori",
                PhoneNumber = "+38344224106",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                OrdinanceId = null,
                SecurityStamp = Guid.NewGuid().ToString(),
                LockoutEnabled = false,
                UserName = "muhamedbrajshori@hotmail.com",
                NormalizedUserName = "muhamedbrajshori@hotmail.com"
            };

            user.PasswordHash = new PasswordHasher<User>().HashPassword(user, "MuhamedBetina@2021");

            modelBuilder.Entity<User>().HasData(user);

            SeedUserClaims(modelBuilder, user);
        }

        private void SeedUserClaims(ModelBuilder modelBuilder, User user)
        {
            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(
                new IdentityUserClaim<string>
                {
                    ClaimType = ClaimTypes.NameIdentifier,
                    UserId = user.Id, 
                    Id = 1,
                    ClaimValue = user.Id
                },
                new IdentityUserClaim<string>
                {
                    ClaimType = ClaimTypes.Email,
                    UserId = user.Id,
                    Id = 2,
                    ClaimValue = user.Email
                },
                new IdentityUserClaim<string>
                {
                    ClaimType = ClaimTypes.Role,
                    UserId = user.Id,
                    Id = 3,
                    ClaimValue = "Super Admin"
                },
                new IdentityUserClaim<string>
                {
                    ClaimType = ClaimTypes.MobilePhone,
                    UserId = user.Id,
                    Id = 4,
                    ClaimValue = user.PhoneNumber
                },
                new IdentityUserClaim<string>
                {
                    ClaimType = ClaimTypes.GivenName,
                    UserId = user.Id,
                    Id = 5,
                    ClaimValue = user.FirstName
                },
                new IdentityUserClaim<string>
                {
                    ClaimType = ClaimTypes.Surname,
                    UserId = user.Id,
                    Id = 6,
                    ClaimValue = user.LastName
                });
        }

        private void SeedUserRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "12BC2784-B550-5876-98A8-74A621C6E6B8",
                    UserId = "9A6EA564-7238-5CD6-BD64-DA142DD43FF5"
                });
        }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = "12BC2784-B550-5876-98A8-74A621C6E6B8",
                    NormalizedName = "SuperAdmin",
                    Name = "SuperAdmin"
                },
                new Role
                {
                    Id = "4FFB4345-CA1C-5050-AB1F-3AE2BE5E46D5",
                    NormalizedName = "Tenant",
                    Name = "Tenant"
                });
        }
    }
}
