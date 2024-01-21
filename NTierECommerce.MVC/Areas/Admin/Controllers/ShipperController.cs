using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTierECommerce.BLL.Abstracts;
using NTierECommerce.Entities.Entities;
using NTierECommerce.MVC.Areas.Admin.Models.ViewModels;

namespace NTierECommerce.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ShipperController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IShipperRepository _shipperRepository;

        public ShipperController(IMapper mapper, IShipperRepository shipperRepository)
        {
            _mapper = mapper;
            _shipperRepository = shipperRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var getShippers = await _shipperRepository.GetAll();
            List<ShipperVM> ShipperListVM = _mapper.Map<List<ShipperVM>>(getShippers);

            return View(ShipperListVM);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var getShipper = await _shipperRepository.GetById(id);
            if (getShipper == null) return View();

            ShipperVM shipperVM = _mapper.Map<ShipperVM>(getShipper);

            return View(shipperVM);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ShipperVM shipperVM)
        {
            var getShipper = await _shipperRepository.GetByCompanyName(shipperVM.CompanyName);
            if (getShipper == null)
            {
                Shipper shipper = _mapper.Map<Shipper>(shipperVM);
                await _shipperRepository.Create(shipper);

                return View();
            }
            else
            {
                TempData["Error"] = "Bu isimde firma adı bulunmaktadır!";
                return View(shipperVM);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var getShipper = await _shipperRepository.GetById(id);
            if(getShipper == null) return View();

            ShipperVM shipperVM = _mapper.Map<ShipperVM>(getShipper);

            return View(shipperVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ShipperVM shipperVM)
        {
            var getShipper = await _shipperRepository.GetById(shipperVM.ID);
            if (getShipper == null) return View(shipperVM);

            Shipper shipper = _mapper.Map<Shipper>(shipperVM);

             await _shipperRepository.Update(shipper);

            return RedirectToAction("Index","Shipper");
        }

        public async Task<IActionResult> Destroy(int id)
        {
            var getShipper = await _shipperRepository.GetById(id);
            if (getShipper == null) return View();

            await _shipperRepository.DestroyData(getShipper);

            return RedirectToAction("Index","Shipper");
        }
    }
}
