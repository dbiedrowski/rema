using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace REMA.Models
{
    public class Landlord
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
