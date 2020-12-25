using REMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMA.Data
{
    public interface ILandlordRepository
    {  
        public Landlord CreateLandlord(Landlord landlord);
        public Landlord GetLandlord(int id);
        public Landlord GetLandlord(string userId);
        IEnumerable<Landlord> AllLandlords { get; }
        public Landlord UpdateLandlord(Landlord landlord);
        public Landlord DeleteLandlord(int id);
    }
}
