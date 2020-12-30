using REMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMA.ViewModels
{
    public class ApartmentViewModel
    {
        // Apartment address information
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        // The rest of apartment information
        public int Floor { get; set; }

        // Building type
        public string Type { get; set; }
        public int BuildingFloors { get; set; }
        public DateTime AvailableSince { get; set; }
        public double Area { get; set; }

        internal Apartment ToDomainModel()
        {
            return new Apartment()
            {
                Address = new Address
                {
                    StreetName = StreetName,
                    StreetNumber = StreetNumber,
                    City = City,
                    ZipCode = ZipCode,
                    State = State,
                    Country = Country
                },
                Floor = Floor,
                Type = 0,   // TODO create a radio button with int value and string representation, and assign that value to this
                BuildingFloors = BuildingFloors,
                AvailableSince = AvailableSince,
                Area = Area
            };
        }

        internal static IEnumerable<ApartmentViewModel> ToApartmentViewModels(
            IEnumerable<Apartment> apartments)
        {
            List<ApartmentViewModel> viewModels = new List<ApartmentViewModel>();
            foreach(var apartment in apartments)
            {
                viewModels.Add(ApartmentViewModel.ToApartmentViewModel(apartment));
            }

            return viewModels.AsEnumerable();
        }

        internal static ApartmentViewModel ToApartmentViewModel(Apartment apartment)
        {
            ApartmentViewModel apartmentViewModel = new ApartmentViewModel()
            {
                StreetName = apartment.Address.StreetName,
                StreetNumber = apartment.Address.StreetNumber,
                City = apartment.Address.City,
                ZipCode = apartment.Address.ZipCode,
                State = apartment.Address.State,
                Country = apartment.Address.Country,
                Floor = apartment.Floor,
                Type = apartment.Type.ToString(),
                BuildingFloors = apartment.BuildingFloors,
                AvailableSince = apartment.AvailableSince,
                Area = apartment.Area
            };

            return apartmentViewModel;
        }
    }
}
