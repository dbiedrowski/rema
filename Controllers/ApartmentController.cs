﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REMA.Data;
using REMA.Models;
using REMA.ViewModels;
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
            IEnumerable<DetailsUpdateDeleteApartmentViewModel> apartmentViewModels =
                DetailsUpdateDeleteApartmentViewModel.ToViewModels(apartments);
            return View(apartmentViewModels);
        }

        [HttpGet]
        public IActionResult Add()
        {
            CreateApartmentViewModel apartmentViewModel = new CreateApartmentViewModel();

            return View(apartmentViewModel);
        }

        [HttpPost]
        public IActionResult Add(CreateApartmentViewModel apartmentViewModel)
        {
            Apartment apartment = apartmentViewModel.ToDomainModel();
            apartment.Landlord = _landlord;
            apartment.LandlordId = _landlord.LandlordId;

            _apartmentRepository.Create(apartment);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int apartmentId)
        {
            Apartment apartment = _apartmentRepository.GetById(apartmentId);

            if(apartment == null)
            {
                return NotFound();
            }

            DetailsUpdateDeleteApartmentViewModel viewModel
                = DetailsUpdateDeleteApartmentViewModel.ToViewModel(apartment);

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Update(int apartmentId)
        {
            Apartment apartment = _apartmentRepository.GetById(apartmentId);

            if (apartment == null)
            {
                return NotFound();
            }

            DetailsUpdateDeleteApartmentViewModel viewModel
                = DetailsUpdateDeleteApartmentViewModel.ToViewModel(apartment);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(DetailsUpdateDeleteApartmentViewModel viewModel)
        {
            _apartmentRepository.Update(viewModel.ToDomainModel());
            return RedirectToAction("Index");
        }
    }
}
