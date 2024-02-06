using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NTierECommerce.BLL.Abstracts;
using NTierECommerce.Entities.Entities;
using NTierECommerce.MVC.Models.ViewModels.MyCart;

namespace NTierECommerce.MVC.Controllers
{
	[Authorize]
	public class MyAddressesController : Controller
	{
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
		private readonly IShippingAddressService _shippingAddressRepository;

		public MyAddressesController(IMapper mapper,UserManager<AppUser> userManager,IShippingAddressService shippingAddressRepository)
        {
            _mapper = mapper;
            _userManager = userManager;
			_shippingAddressRepository = shippingAddressRepository;
		}
        public async Task<IActionResult> Index(int? addressid)
		{

			await MyAddressList();
			if (addressid > 0)
			{
				var getUser = await _userManager.FindByNameAsync(User.Identity.Name);
				var getMyAddress = await _shippingAddressRepository.GetByUserIdAndAddressId(getUser.Id, (int)addressid);
				if (getMyAddress != null)
				{
					ShippingAddressVM shippingAddressVM = _mapper.Map<ShippingAddressVM>(getMyAddress);

					return View(shippingAddressVM);
				}
			}
			return View();
		}

		public IActionResult ShippingAddressAdd()
		{
			return RedirectToAction("Index", "MyAddresses");
		}
		[HttpPost]
		public async Task<IActionResult> ShippingAddressAdd(ShippingAddressVM shippingAddressVM)
		{

			var getUser = await _userManager.FindByNameAsync(User.Identity.Name);
			
			ShippingAddress shippingAddress = _mapper.Map<ShippingAddress>(shippingAddressVM);
			shippingAddress.AppUser = getUser;


			await _shippingAddressRepository.Create(shippingAddress);

			return RedirectToAction("Index", "MyAddresses");
		}

		public IActionResult ShippingAddressUpdate()
		{
			return RedirectToAction("Index", "MyAddresses");
		}

		[HttpPost]
		public async Task<IActionResult> ShippingAddressUpdate(ShippingAddressVM shippingAddressVM)
		{
			var getUser = await _userManager.FindByNameAsync(User.Identity.Name);
			var getMyAddress = await _shippingAddressRepository.GetByUserIdAndAddressId(getUser.Id, shippingAddressVM.Id);
			if (getMyAddress != null)
			{
                ShippingAddress shippingAddress = _mapper.Map<ShippingAddress>(shippingAddressVM);
                shippingAddress.AppUserId = getUser.Id;

                await _shippingAddressRepository.Update(shippingAddress);
			}
			return RedirectToAction("Index", "MyAddresses");
		}

		public IActionResult ShippingAddressDelete()
		{
			return RedirectToAction("Index", "MyAddresses");
		}

		[HttpPost]
		public async Task<IActionResult> ShippingAddressDelete(int addressid)
		{
			var getUser = await _userManager.FindByNameAsync(User.Identity.Name);
			var getMyAddress = await _shippingAddressRepository.GetByUserIdAndAddressId(getUser.Id, addressid);
			if (getMyAddress != null)
			{
				await _shippingAddressRepository.Delete(getMyAddress);
			}
			return RedirectToAction("Index", "MyAddresses");
		}

		public async Task MyAddressList()
		{
			var getUser = await _userManager.FindByNameAsync(User.Identity.Name);
			var getMyAddress = await _shippingAddressRepository.GetByUserIdAddressList(getUser.Id);

			var getUserAddres = getMyAddress.Select(x => new ShippingAddress
			{
				Id = x.Id,
				AddressName = x.AddressName
			}).Select(sa => new SelectListItem
			{
				Text = sa.AddressName,
				Value = sa.Id.ToString()
			});

			ViewBag.ShippingAddress = getUserAddres;
		}
	}
}
