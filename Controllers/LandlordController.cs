using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REMA.Data;
using REMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace REMA.Controllers
{
    [Authorize]
    public class LandlordController : Controller
    {
        private readonly ILandlordRepository landlordRepository;
        private readonly IProfileRepository profileRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LandlordController(ILandlordRepository landlordRepository,
                                    IProfileRepository profileRepository,
                                    IHttpContextAccessor httpContextAccessor)
        {
            this.landlordRepository = landlordRepository;
            this.profileRepository = profileRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            IEnumerable <Landlord> landlords = landlordRepository.AllLandlords;
            return View(landlords);
        }
    }
}
