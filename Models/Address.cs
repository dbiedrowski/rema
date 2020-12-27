using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace REMA.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }

        public override string ToString()
        {
            return $"{StreetName} {StreetNumber}, {ZipCode} {City}";
        }
    }
}