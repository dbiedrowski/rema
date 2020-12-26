using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMA.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        public Address Address { get; set; }
        public int Floor { get; set; }
        public BuildingType Type { get; set; }
        public int BuildingFloors { get; set; }
        public DateTime AvailableSince { get; set; }
        public double Area { get; set; }
        
    }
}
