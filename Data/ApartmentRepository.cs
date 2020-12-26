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
                .FirstOrDefault(a => a.ApartmentId == id);
        }

        public IEnumerable<Apartment> GetByLandlord(Landlord landlord)
        {
            return _context.Apartments
                .Include(a => a.Address)
                .Where(a => a.Landlord.LandlordId == landlord.LandlordId);
        }

        public Apartment Update(Apartment apartment)
        {
            if (_context.Apartments.Find(apartment.ApartmentId) != null)
            {
                _context.Apartments.Update(apartment);
                _context.SaveChanges();
            }

            return apartment;
        }
    }
}
