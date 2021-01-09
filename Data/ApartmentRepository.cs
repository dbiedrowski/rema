using Microsoft.EntityFrameworkCore;
using REMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMA.Data
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly AppDbContext _context;

        public ApartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public Apartment Create(Apartment apartment)
        {
            _context.Apartments.Add(apartment);
            _context.SaveChanges();

            return apartment;
        }

        public Apartment Delete(int id)
        {
            Apartment apartment = GetById(id);

            if(apartment != null)
            {
                _context.Apartments.Remove(apartment);
                _context.SaveChanges();
            }

            return apartment;
        }

        public Apartment GetById(int id)
        {
            return _context.Apartments
                .Include(a => a.Address)
                .Include(r => r.Rooms)
                .FirstOrDefault(a => a.ApartmentId == id);
        }

        public IEnumerable<Apartment> GetByLandlord(Landlord landlord)
        {
            return _context.Apartments
                .Include(a => a.Address)
                .Include(r => r.Rooms)
                .Where(a => a.Landlord.LandlordId == landlord.LandlordId);
        }

        public Apartment Update(Apartment newApartment)
        {
            if (_context.Apartments.Find(newApartment.ApartmentId) != null)
            {
                Apartment current = GetById(newApartment.ApartmentId);

                current.Address.City = newApartment.Address.City;
                current.Address.Country = newApartment.Address.Country;
                current.Address.State = newApartment.Address.State;
                current.Address.StreetName = newApartment.Address.StreetName;
                current.Address.StreetNumber = newApartment.Address.StreetNumber;
                current.Address.ZipCode = newApartment.Address.ZipCode;

                current.Area = newApartment.Area;
                current.AvailableSince = newApartment.AvailableSince;
                current.BuildingFloors = newApartment.BuildingFloors;
                current.BuildingType = newApartment.BuildingType;
                current.Floor = newApartment.Floor;
                current.NumberOfRooms = newApartment.NumberOfRooms;

                _context.SaveChanges();
            }

            return newApartment;
        }
    }
}
