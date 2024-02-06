using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NTierECommerce.BLL.Abstracts;
using NTierECommerce.Entities.Entities;
using NTierECommerce.MVC.Areas.Admin.Models.ViewModels;

namespace NTierECommerce.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly IOrderService _orderRepository;
        private readonly IOrderDetailService _orderDetailRepository;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(IOrderService orderRepository,IOrderDetailService orderDetailRepository,UserManager<AppUser> userManager)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var getOrders = await _orderRepository.GetAll();
            List<OrderVM> dashBoardOrderVMs = new List<OrderVM>();

            foreach (var order in getOrders.OrderByDescending(x=>x.OrderDate))
            {
                dashBoardOrderVMs.Add(new OrderVM
                {
                    OrderId = order.OrderId,
                    OrderDate = order.OrderDate,
                    TotalPrice = _orderDetailRepository.GetByOrderIDTotalPrice(order.OrderId).Result,
                });
            }

            DashBoardVM dashBoardVM = new DashBoardVM
            {
                TotalOrderCount = _orderRepository.GetAllCount().Result,
                TotalEarning = _orderDetailRepository.GetTotalEarning().Result,
                MonthlyOrderCount = _orderRepository.GetMonthlyCount().Result,
                AppUserCount = _userManager.Users.Count(),
                DashBoardOrders = dashBoardOrderVMs
            };
            return View(dashBoardVM);
        }

	}
}
