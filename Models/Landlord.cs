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
        [Key]
        public int Id { get; set; }

        [ForeignKey("Id")]
        public Profile Profile { get; set; }
    }
}
