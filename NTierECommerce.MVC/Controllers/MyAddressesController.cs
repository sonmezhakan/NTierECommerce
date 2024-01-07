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
		private readonly UserManager<AppUser> _userManager;
		private readonly IShippingAddressRepository _shippingAddressRepository;

		public MyAddressesController(UserManager<AppUser> userManager,IShippingAddressRepository shippingAddressRepository)
        {
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
					ShippingAddressVM shippingAddressVM = new ShippingAddressVM()
					{
						ShippingAddressId = getMyAddress.Id,
						FirstName = getMyAddress.FirstName,
						LastName = getMyAddress.LastName,
						AddressName = getMyAddress.AddressName,
						Address = getMyAddress.Address,
						PhoneNumber = getMyAddress.PhoneNumber
					};

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

			ShippingAddress shippingAddress = new ShippingAddress()
			{
				AddressName = shippingAddressVM.AddressName,
				FirstName = shippingAddressVM.FirstName,
				LastName = shippingAddressVM.LastName,
				PhoneNumber = shippingAddressVM.PhoneNumber,
				Address = shippingAddressVM.Address,
				AppUserId = getUser.Id
			};

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
			var getMyAddress = await _shippingAddressRepository.GetByUserIdAndAddressId(getUser.Id, shippingAddressVM.ShippingAddressId);
			if (getMyAddress != null)
			{
				ShippingAddress shippingAddress = new ShippingAddress
				{
					Id = shippingAddressVM.ShippingAddressId,
					AddressName = shippingAddressVM.AddressName,
					FirstName = shippingAddressVM.FirstName,
					LastName = shippingAddressVM.LastName,
					PhoneNumber = shippingAddressVM.PhoneNumber,
					Address = shippingAddressVM.Address,
					AppUserId = getUser.Id
				};

				await _shippingAddressRepository.Update(shippingAddress);
			}
			return RedirectToAction("Index", "MyAddresses");
		}

		public IActionResult ShippingAddressDelete()
		{
			return RedirectToAction("Index", "MyAddresses");
		}

		[HttpPost]
		public async Task<IActionResult> ShippingAddressDelete(int shippingaddressid)
		{
			var getUser = await _userManager.FindByNameAsync(User.Identity.Name);
			var getMyAddress = await _shippingAddressRepository.GetByUserIdAndAddressId(getUser.Id, shippingaddressid);
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
