using REMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMA.Data
{
    public interface IRoomRepository
    {
        public Room Create(Room room);
        public Room GetById(int roomId);
        public IEnumerable<Room> GetByApartment(int apartmentId);
        public Room Update(Room room);
        public Room Delete(int roomId);
    }
}
