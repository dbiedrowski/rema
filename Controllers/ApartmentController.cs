﻿using Microsoft.AspNetCore.Authorization;
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
        private readonly Landlord _landlord;

        public ApartmentController(ILandlordRepository landlordReporitory,
                                    IApartmentRepository apartmentRepository,
                                    IHttpContextAccessor httpContextAccessor)
        {
            _landlordRepository = landlordReporitory;
            _apartmentRepository = apartmentRepository;
            _httpContextAccessor = httpContextAccessor;

            var userId = _httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier).Value;
            _landlord = _landlordRepository.GetLandlord(userId);
        }

        public IActionResult Index()
        {
            IEnumerable<Apartment> apartments = _apartmentRepository.GetByLandlord(_landlord);
            return View(apartments);
        }

        [HttpGet]
        public IActionResult Add()
        {
            Apartment apartment = new Apartment();

            return View(apartment);
        }

        [HttpPost]
        public IActionResult Add(Apartment apartment)
        {
            apartment.Landlord = _landlord;
            apartment.LandlordId = _landlord.LandlordId;

            _apartmentRepository.Create(apartment);

            return RedirectToAction("Index");
        }
    }
}