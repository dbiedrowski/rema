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
    public class ApartmentController : Controller
    {
        private readonly ILandlordRepository _landlordRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApartmentController(ILandlordRepository landlordReporitory,
                                    IApartmentRepository apartmentRepository,
                                    IHttpContextAccessor httpContextAccessor)
        {
            _landlordRepository = landlordReporitory;
            _apartmentRepository = apartmentRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Landlord landlord = _landlordRepository.GetLandlord(userId);
            IEnumerable<Apartment> apartments = _apartmentRepository.GetByLandlord(landlord);
            return View(apartments);
        }
    }
}
