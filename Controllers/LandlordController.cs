using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using REMA.Data;
using REMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMA.Controllers
{
    [Authorize]
    public class LandlordController : Controller
    {
        private readonly ILandlordRepository landlordRepository;
        private readonly IProfileRepository profileRepository;

        public LandlordController(ILandlordRepository landlordRepository, IProfileRepository profileRepository)
        {
            this.landlordRepository = landlordRepository;
            this.profileRepository = profileRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Landlord> landlords = landlordRepository.AllLandlords;
            return View(landlords);
        }
    }
}
