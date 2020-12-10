using REMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMA.Data
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly AppDbContext _context;

        public ProfileRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Profile> AllProfiles
        {
            get
            {
                return _context.Profiles.AsEnumerable<Profile>();
            }
        }

        public Profile CreateProfile(Profile profile)
        {
            _context.Profiles.Add(profile);
            _context.SaveChanges();

            return profile;
        }

        public Profile DeleteProfile(int id)
        {
            var profile = GetProfile(id);

            if(profile != null)
            {
                _context.Profiles.Remove(profile);
                _context.SaveChanges();
            }

            return profile;
        }

        public Profile GetProfile(int id)
        {
            return _context.Profiles.FirstOrDefault(llord => llord.Id == id);
        }

        public Profile UpdateProfile(Profile profile)
        {
            if (_context.Profiles.Find(profile.Id) != null)
            {
                _context.Profiles.Update(profile);
                _context.SaveChanges();
            }

            return profile;
        }
    }
}
