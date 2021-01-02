using REMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMA.ViewModels
{
    public class CreateApartmentViewModel
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
        public BuildingType BuildingType { get; set; }
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
                BuildingType = BuildingType,
                BuildingFloors = BuildingFloors,
                AvailableSince = AvailableSince,
                Area = Area
            };
        }

        internal static IEnumerable<CreateApartmentViewModel> ToApartmentViewModels(
            IEnumerable<Apartment> apartments)
        {
            List<CreateApartmentViewModel> viewModels = new List<CreateApartmentViewModel>();
            foreach(var apartment in apartments)
            {
                viewModels.Add(CreateApartmentViewModel.ToApartmentViewModel(apartment));
            }

            return viewModels.AsEnumerable();
        }

        internal static CreateApartmentViewModel ToApartmentViewModel(Apartment apartment)
        {
            CreateApartmentViewModel apartmentViewModel = new CreateApartmentViewModel()
            {
                StreetName = apartment.Address.StreetName,
                StreetNumber = apartment.Address.StreetNumber,
                City = apartment.Address.City,
                ZipCode = apartment.Address.ZipCode,
                State = apartment.Address.State,
                Country = apartment.Address.Country,
                Floor = apartment.Floor,
                BuildingType = apartment.BuildingType,
                BuildingFloors = apartment.BuildingFloors,
                AvailableSince = apartment.AvailableSince,
                Area = apartment.Area
            };

            return apartmentViewModel;
        }
    }
}
