using System;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;

namespace PotholeTrack.Data
{
    public class SeedUsers
    {
        public static PasswordHasher<ApplicationUser> passwordHasher = null;

        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }
            
            string password = "Password123!";
            string hashedPass = "PKXuMvhzZWFnZ9twkrIrHS88YLdlwcxwFK1KjCHlxpc=";

            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            var users = new ApplicationUser[]
            {
                new ApplicationUser
                {
                    Id ="1",
                    AccessFailedCount =0,
                    Email ="samack@gmail.com",
                    EmailConfirmed =true,
                    PasswordHash = hashedPass,
                    LockoutEnabled =false,
                    PhoneNumberConfirmed =false,
                    TwoFactorEnabled =false,
                    UserName ="samack@gmail.com"
                }
                //new ApplicationUser
                //{
                //    Id ="2",
                //    AccessFailedCount =0,
                //    Email ="samack@gmail.com",
                //    EmailConfirmed =true,
                //    LockoutEnabled =false,
                //    PhoneNumberConfirmed =false,
                //    TwoFactorEnabled =false,
                //    UserName ="samack@gmail.com"
                //},
                //new ApplicationUser
                //{
                //    Id ="4",
                //    AccessFailedCount =0,
                //    Email ="annagabriellareed@gmail.com",
                //    EmailConfirmed =true,
                //    LockoutEnabled =false,
                //    PhoneNumberConfirmed =false,
                //    TwoFactorEnabled =false,
                //    UserName ="annagabriellareed@gmail.com"
                //},
                //new ApplicationUser
                //{
                //    Id ="5",
                //    AccessFailedCount =0,
                //    Email ="raffy.guiao@gmail.com",
                //    EmailConfirmed =true,
                //    LockoutEnabled =false,
                //    PhoneNumberConfirmed =false,
                //    TwoFactorEnabled =false,
                //    UserName ="raffy.guiao@gmail.com"
                //}
            };

            foreach (ApplicationUser a in users)
            {
                context.Users.Add(a);
            }
            context.SaveChanges();
        }

    }
}




