
using System;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace PotholeTrack.Data
{
    public class SeedUsers
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            String password="Password123!";

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
                    Email ="admin@example.com",
                    EmailConfirmed =true,
                    LockoutEnabled =false,
                    PasswordHash = hashed,
                    PhoneNumberConfirmed =false,
                    TwoFactorEnabled =false,
                    UserName ="Admin"
                }

            };
            foreach (ApplicationUser a in users)
            {
                context.Users.Add(a);
            }
            context.SaveChanges();
        }

    }
}




