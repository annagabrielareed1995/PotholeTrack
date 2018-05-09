using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PotholeTrack.Models
{
    public class DbInitializer
    {
        public static void Initialize(PotholeContext context)
        {
            context.Database.EnsureCreated();

            // Look for any potholes.
            if (context.Pothole.Any())
            {
                return;   // DB has been seeded
            }

            var potholes = new Pothole[]
            {
            new Pothole{Latitude=32.7157,Longitude=117.1611,Severity=10},
            new Pothole{Latitude=32.7247,Longitude=117.4253,Severity=5},
            new Pothole{Latitude=32.7175,Longitude=117.7531,Severity=5},
            new Pothole{Latitude=32.3156,Longitude=117.8432,Severity=1},
            new Pothole{Latitude=32.4853,Longitude=117.3572,Severity=3},
            new Pothole{Latitude=32.4362,Longitude=117.6738,Severity=9},
            new Pothole{Latitude=32.8642,Longitude=117.7134,Severity=5},
            new Pothole{Latitude=32.9285,Longitude=117.5623,Severity=15}
            };
            foreach (Pothole p in potholes)
            {
                context.Pothole.Add(p);
            }
            context.SaveChanges();
        }
    }
}
