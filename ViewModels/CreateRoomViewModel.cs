using REMA.Enums;
using REMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMA.ViewModels
{
    public class CreateRoomViewModel
    {
        public decimal Price { get; set; }
        public RoomType RoomType { get; set; }
        public double Area { get; set; }
        public bool IsFurnished { get; set; }
        public int ApartmentId { get; set; }

        internal Room ToDomainModel()
        {
            return new Room()
            {
                ApartmentId = ApartmentId,
                Area = Area,
                IsFurnished = IsFurnished,
                Price = Price,
                RoomType = RoomType
            };
        }
    }
}
