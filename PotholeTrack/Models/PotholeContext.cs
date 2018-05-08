using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PotholeTrack.Models
{
    public class PotholeContext : DbContext
    {
        public PotholeContext(DbContextOptions<PotholeContext> options) : base(options)
        {

        }

        public DbSet<Pothole> Pothole { get; set; }
    }
}
