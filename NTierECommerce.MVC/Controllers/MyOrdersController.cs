using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NTierECommerce.BLL.Abstracts;
using NTierECommerce.Entities.Entities;
using NTierECommerce.MVC.Models.ViewModels.MyOrder;

namespace NTierECommerce.MVC.Controllers
{
    [Authorize]
    public class MyOrdersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IOrderRepository _orderRepository;
        private readonly IShipperRepository _shipperRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public MyOrdersController(UserManager<AppUser> userManager,IOrderRepository orderRepository, IShipperRepository shipperRepository, IOrderDetailRepository orderDetailRepository, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _userManager = userManager;
            _orderRepository = orderRepository;
            _shipperRepository = shipperRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var getUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var getOrderList = await _orderRepository.GetByUserId(getUser.Id);

            List<MyOrderListVM> myOrderLists = new List<MyOrderListVM>();
            foreach (var item in getOrderList.OrderByDescending(x => x.OrderDate))
            {
                var getShipper = await _shipperRepository.GetById((int)item.ShipperId);
                MyOrderListVM myOrderListVM = new MyOrderListVM();
                myOrderListVM.OrderId = item.OrderId;
                myOrderListVM.OrderDate = item.OrderDate;
                myOrderListVM.ShipNumber = item.ShipNumber;
                myOrderListVM.ShipperName = getShipper.CompanyName;
                myOrderListVM.ShipStatus = "Yolda";
                myOrderLists.Add(myOrderListVM);
            }

            return View(myOrderLists);
        }
        
        public async Task<IActionResult> Detail(int orderid)
        {
            var getUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var getOrder = await _orderRepository.GetByUserAndOrderId(getUser.Id,orderid);
            if(getOrder != null)
            {
                var getOrderDetail = await _orderDetailRepository.GetByIdList(orderid);

                List<OrderDetailVM> orderdetails = new List<OrderDetailVM>();
                foreach (var item in getOrderDetail)
                {
                    var getProduct = await _productRepository.GetById(item.ProductId);
                    var getCategory = await _categoryRepository.GetById(getProduct.CategoryId);
                    OrderDetailVM orderDetailVM = new OrderDetailVM()
                    {
                        OrderId = item.OrderId,
                        OrderDate = getOrder.OrderDate,
                        ProductName = getProduct.ProductName,
                        ImagePath = getProduct.ImagePath,
                        CategoryName = getCategory.CategoryName,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        SubTotalPrice = item.Quantity * item.UnitPrice
                    };

                    orderdetails.Add(orderDetailVM);
                }
                return View(orderdetails);
            }
            return RedirectToAction("Index", "MyOrders");            
        }
    }
}
