using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using REMA.Data;
using REMA.Models;
using REMA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMA.Controllers
{
    [Authorize]
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IApartmentRepository _apartmentRepository;

        public RoomController(IRoomRepository roomRepository,
                                IApartmentRepository apartmentRepository)
        {
            _roomRepository = roomRepository;
            _apartmentRepository = apartmentRepository;
        }

        [HttpGet]
        public IActionResult Add(int apartmentId)
        {
            Apartment apartment = _apartmentRepository.GetById(apartmentId);
            
            if(apartment == null)
            {
                return NotFound();
            }
            
            if(apartment.Rooms.Count < apartment.NumberOfRooms)
            {
                CreateRoomViewModel viewModel = new CreateRoomViewModel();
                viewModel.ApartmentId = apartmentId;
                return View(viewModel);
            }
            else
            {
                TempData["AttemptedToAddRoomToFullApartment"] =
                    "You cannot add more rooms to this apartment.";
                return RedirectToAction("Details", "Apartment", new { apartmentId = apartmentId });
            }
        }

        [HttpPost]
        public IActionResult Add(CreateRoomViewModel viewModel)
        {
            _roomRepository.Create(viewModel.ToDomainModel());
            return RedirectToAction("Details", "Apartment", new { apartmentId = viewModel.ApartmentId });
        }

        [HttpGet]
        public IActionResult Update(int roomId)
        {
            return HelperForHttpGetDetailsUpdateDelete(roomId);
        }

        [HttpPost]
        public IActionResult Update(DetailsUpdateDeleteRoomViewModel viewModel)
        {
            _roomRepository.Update(viewModel.ToDomainModel());
            return RedirectToAction("Details", "Apartment", new { apartmentId = viewModel.ApartmentId });
        }

        [HttpGet]
        public IActionResult Delete(int roomId)
        {
            return HelperForHttpGetDetailsUpdateDelete(roomId);
        }

        [HttpPost]
        public IActionResult Delete(DetailsUpdateDeleteRoomViewModel viewModel)
        {
            _roomRepository.Delete(viewModel.RoomId);
            return RedirectToAction("Details", "Apartment", new { apartmentId = viewModel.ApartmentId });
        }

        private IActionResult HelperForHttpGetDetailsUpdateDelete(int roomId)
        {
            Room room = _roomRepository.GetById(roomId);

            if (room == null)
            {
                return NotFound();
            }

            return View(DetailsUpdateDeleteRoomViewModel.ToViewModel(room));
        }
    }
}
