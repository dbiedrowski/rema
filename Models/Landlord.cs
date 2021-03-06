﻿using System;
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
        public int LandlordId { get; set; }

        [ForeignKey("Profile")]
        public int ProfileId { get; set; }
        public string UserId { get; set; }
        public Profile Profile { get; set; }
        public List<Apartment> Apartments { get; set; }
    }
}
