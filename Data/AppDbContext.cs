using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using REMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMA.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Landlord> Landlords { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // seed profiles
            Profile damian = new Profile { ProfileId = 1, FirstName = "Damian", LastName = "Biedrowski" };
            Profile konrad = new Profile { ProfileId = 2, FirstName = "Konrad", LastName = "Biedrowski" };

            builder.Entity<Profile>().HasData(damian);
            builder.Entity<Profile>().HasData(konrad);

            // seed landlords
            builder.Entity<Landlord>().HasData(new Landlord { Id = 1, ProfileId = 1});
            builder.Entity<Landlord>().HasData(new Landlord { Id = 2, ProfileId = 2});
        }
    }
}
