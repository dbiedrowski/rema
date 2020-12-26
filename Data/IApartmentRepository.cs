using REMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMA.Data
{
    interface IApartmentRepository
    {
        public ApartmentRepository Create(ApartmentRepository apartment);
        public ApartmentRepository GetById(int id);
        public ApartmentRepository GetByLandlord(Landlord landlord);
        public ApartmentRepository Update(ApartmentRepository apartment);
        public ApartmentRepository Delete(int id);
    }
}
