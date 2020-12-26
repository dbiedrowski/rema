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
        public string Address { get; set; }
        public int Floor { get; set; }
        public string Type { get; set; }
        public int BuildingFloors { get; set; }
        public DateTime AvailableSince { get; set; }
        public double Area { get; set; }
        public Landlord Landlord { get; set; }

    }
}
