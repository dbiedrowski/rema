using REMA.Enums;
using REMA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace REMA.ViewModels
{
    public class DetailsUpdateDeleteRoomViewModel
    {
        public int RoomId { get; set; }
        public decimal Price { get; set; }
        public RoomType RoomType { get; set; }
        public double Area { get; set; }
        public bool IsFurnished { get; set; }
        public int ApartmentId { get; set; }

        internal Room ToDomainModel()
        {
            return new Room()
            {
                RoomId = RoomId,
                ApartmentId = ApartmentId,
                Area = Area,
                IsFurnished = IsFurnished,
                Price = Price,
                RoomType = RoomType
            };
        }

        public static DetailsUpdateDeleteRoomViewModel ToViewModel(Room room)
        {
            return new DetailsUpdateDeleteRoomViewModel()
            {
                ApartmentId = room.ApartmentId,
                Area = room.Area,
                IsFurnished = room.IsFurnished,
                Price = room.Price,
                RoomId = room.RoomId,
                RoomType = room.RoomType
            };
        }

        internal static BindingList<DetailsUpdateDeleteRoomViewModel> ToViewModels(
            List<Room> rooms)
        {
            BindingList<DetailsUpdateDeleteRoomViewModel> viewModels
                = new BindingList<DetailsUpdateDeleteRoomViewModel>();
            foreach (var room in rooms)
            {
                viewModels.Add(DetailsUpdateDeleteRoomViewModel.ToViewModel(room));
            }

            return viewModels;
        }

        internal static List<Room> ToDomainModels(
            BindingList<DetailsUpdateDeleteRoomViewModel> viewModels)
        {
            List<Room> rooms = new List<Room>();
            foreach (var viewModel in viewModels)
            {
                rooms.Add(viewModel.ToDomainModel());
            }

            return rooms;
        }
    }
}
