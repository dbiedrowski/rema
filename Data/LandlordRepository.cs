﻿using Microsoft.EntityFrameworkCore;
using REMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMA.Data
{
    public class LandlordRepository : ILandlordRepository
    {
        private readonly AppDbContext _context;

        public LandlordRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Landlord> AllLandlords
        {
            get
            {
                return _context.Landlords
                    .Include(l => l.Profile)
                    .AsEnumerable<Landlord>();
            }
        }

        public Landlord CreateLandlord(Landlord landlord)
        {
            if(landlord.Profile == null)
            {
                landlord.Profile = new Profile();
            }

            _context.Landlords.Add(landlord);
            _context.SaveChanges();

            return landlord;
        }

        public Landlord DeleteLandlord(int id)
        {
            var landlord = GetLandlord(id);

            if(landlord != null)
            {
                _context.Landlords.Remove(landlord);
                _context.SaveChanges();
            }

            return landlord;
        }

        public Landlord GetLandlord(int id)
        {
            return _context.Landlords
                .Include(l => l.Profile)
                .FirstOrDefault(llord => llord.LandlordId == id);
        }

        public Landlord GetLandlord(string userId)
        {
            return _context.Landlords
                .Include(l => l.Profile)
                .FirstOrDefault(llord => llord.UserId == userId);
        }

        public Landlord UpdateLandlord(Landlord landlord)
        {
            if (_context.Landlords.Find(landlord.LandlordId) != null)
            {
                _context.Landlords.Update(landlord);
                _context.SaveChanges();
            }

            return landlord;
        }
    }
}
