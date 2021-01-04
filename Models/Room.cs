using REMA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMA.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public decimal Price { get; set; }
        public RoomType RoomType { get; set; }
        public double Area { get; set; }
        public bool IsFurnished { get; set; }
        public Apartment Apartment { get; set; }
        public int ApartmentId { get; set; }
    }
}
