using Microsoft.EntityFrameworkCore;

namespace REMA.Models
{
    [Keyless]
    public class Address
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
    }
}