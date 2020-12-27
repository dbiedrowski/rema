using REMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMA.Data
{
    public interface IApartmentRepository
    {
        public Apartment Create(Apartment apartment);
        public Apartment GetById(int id);
        public IEnumerable<Apartment> GetByLandlord(Landlord landlord);
        public Apartment Update(Apartment apartment);
        public Apartment Delete(int id);
    }
}
