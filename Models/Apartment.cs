using REMA.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace REMA.Models
{
    public class Apartment
    {
        [Key]
        public int ApartmentId { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int Floor { get; set; }
        public BuildingType BuildingType { get; set; }
        public int BuildingFloors { get; set; }
        public DateTime AvailableSince { get; set; }
        public double Area { get; set; }

        [ForeignKey("Landlord")]
        public int LandlordId { get; set; }
        public Landlord Landlord { get; set; }

    }
}
