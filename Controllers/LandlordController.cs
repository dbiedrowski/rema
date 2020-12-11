using Microsoft.AspNetCore.Mvc;
using REMA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMA.Controllers
{
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
            return View();
        }
    }
}
