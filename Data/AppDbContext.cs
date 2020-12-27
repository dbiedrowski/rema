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
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // seed profiles
            Profile damian = new Profile { ProfileId = 1, FirstName = "Damian", LastName = "Biedrowski" };
            Profile konrad = new Profile { ProfileId = 2, FirstName = "Konrad", LastName = "Biedrowski" };
            builder.Entity<Profile>().HasData(damian);
            builder.Entity<Profile>().HasData(konrad);

            // seed landlords
            Landlord damianLandlord = new Landlord { LandlordId = 1, UserId = "753fe54e-e312-4abd-838e-5e713fd32550", ProfileId = 1 };
            Landlord konradLandlord = new Landlord { LandlordId = 2, UserId = "31704aae-e67a-44b8-b5c1-65551502ea2c", ProfileId = 2 };
            builder.Entity<Landlord>().HasData(damianLandlord);
            builder.Entity<Landlord>().HasData(konradLandlord);

            // seed apartments
            Address damianApartment1Address = new Address {
                AddressId = 1,
                City = "Łódź",
                ZipCode = "93-123",
                StreetName = "Piękna",
                StreetNumber = "1/1"
            };
            Address damianApartment2Address = new Address
            {
                AddressId = 2,
                City = "Łódź",
                ZipCode = "93-234",
                StreetName = "Bestii",
                StreetNumber = "2/12"
            };
            Address konradApartmentAddress = new Address()
            {
                AddressId = 3,
                City = "Łódź",
                ZipCode = "93-345",
                StreetName = "Waleczna",
                StreetNumber = "15/28"
            };
            Apartment damianApartment1 = new Apartment()
            {
                ApartmentId = 1,
                LandlordId = damianLandlord.LandlordId,
                AddressId = damianApartment1Address.AddressId,
                Area = 50.39,
                Floor = 2
            };
            Apartment damianApartment2 = new Apartment()
            {
                ApartmentId = 2,
                LandlordId = damianLandlord.LandlordId,
                AddressId = damianApartment2Address.AddressId,
                Area = 48.12,
                Floor = 0
            };
            Apartment konradApartment = new Apartment()
            {
                ApartmentId = 3,
                LandlordId = konradLandlord.LandlordId,
                AddressId = konradApartmentAddress.AddressId,
                Area = 56.22,
                Floor = 1
            };

            builder.Entity<Address>().HasData(damianApartment1Address);
            builder.Entity<Address>().HasData(damianApartment2Address);
            builder.Entity<Address>().HasData(konradApartmentAddress);
            builder.Entity<Apartment>().HasData(damianApartment1);
            builder.Entity<Apartment>().HasData(damianApartment2);
            builder.Entity<Apartment>().HasData(konradApartment);
        }
    }
}
