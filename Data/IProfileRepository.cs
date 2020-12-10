using REMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMA.Data
{
    public interface IProfileRepository
    {  
        public Profile CreateProfile(Profile profile);
        public Profile GetProfile(int id);
        IEnumerable<Profile> AllProfiles { get; }
        public Profile UpdateProfile(Profile profile);
        public Profile DeleteProfile(Profile profile);
    }
}
