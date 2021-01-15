using Microsoft.AspNetCore.Mvc;
using REMA.Enums;
using REMA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace REMA.ViewModels
{
    public class DetailsUpdateDeleteApartmentViewModel
    {
        // Apartment address information
        public int AddressId { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        // The rest of apartment information
        public int ApartmentId { get; set; }
        public int Floor { get; set; }
        public BuildingType BuildingType { get; set; }
        public int BuildingFloors { get; set; }
        public DateTime AvailableSince { get; set; }
        public double Area { get; set; }
        public List<DetailsUpdateDeleteRoomViewModel> Rooms { get; set; }
        public int NumberOfRooms { get; set; }

        internal Apartment ToDomainModel()
        {
            return new Apartment()
            {
                ApartmentId = ApartmentId,
                Address = new Address
                {
                    AddressId = AddressId,
                    StreetName = StreetName,
                    StreetNumber = StreetNumber,
                    City = City,
                    ZipCode = ZipCode,
                    State = State,
                    Country = Country
                },
                Floor = Floor,
                BuildingType = BuildingType,
                BuildingFloors = BuildingFloors,
                AvailableSince = AvailableSince,
                Area = Area,
                Rooms = DetailsUpdateDeleteRoomViewModel.ToDomainModels(Rooms),
                NumberOfRooms = NumberOfRooms
            };
        }

        internal static IEnumerable<DetailsUpdateDeleteApartmentViewModel> ToViewModels(
            IEnumerable<Apartment> apartments)
        {
            List<DetailsUpdateDeleteApartmentViewModel> viewModels
                = new List<DetailsUpdateDeleteApartmentViewModel>();
            foreach (var apartment in apartments)
            {
                viewModels.Add(DetailsUpdateDeleteApartmentViewModel.ToViewModel(apartment));
            }

            return viewModels.AsEnumerable();
        }

        internal static DetailsUpdateDeleteApartmentViewModel ToViewModel(Apartment apartment)
        {
            DetailsUpdateDeleteApartmentViewModel apartmentViewModel =
                new DetailsUpdateDeleteApartmentViewModel()
            {
                AddressId = apartment.Address.AddressId,
                StreetName = apartment.Address.StreetName,
                StreetNumber = apartment.Address.StreetNumber,
                City = apartment.Address.City,
                ZipCode = apartment.Address.ZipCode,
                State = apartment.Address.State,
                Country = apartment.Address.Country,

                ApartmentId = apartment.ApartmentId,
                Floor = apartment.Floor,
                BuildingType = apartment.BuildingType,
                BuildingFloors = apartment.BuildingFloors,
                AvailableSince = apartment.AvailableSince,
                Area = apartment.Area,
                Rooms = DetailsUpdateDeleteRoomViewModel.ToViewModels(apartment.Rooms),
                NumberOfRooms = apartment.NumberOfRooms
            };

            return apartmentViewModel;
        }
    }
}
