using Microsoft.EntityFrameworkCore;
using REMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMA.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Landlord> Landlords { get; set; }
        public DbSet<Profile> Profiles { get; set; }
    }
}
