using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using REMA.Data;
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

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public IActionResult Add(int apartmentId)
        {
            CreateRoomViewModel viewModel = new CreateRoomViewModel();
            viewModel.ApartmentId = apartmentId;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(CreateRoomViewModel viewModel)
        {
            _roomRepository.Create(viewModel.ToDomainModel());
            return RedirectToAction("Details", "Apartment", new { apartmentId = viewModel.ApartmentId });
        }
    }
}
