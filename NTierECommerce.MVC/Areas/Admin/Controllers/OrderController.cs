using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTierECommerce.BLL.Abstracts;
using NTierECommerce.BLL.Concretes;
using NTierECommerce.Entities.Entities;
using NTierECommerce.MVC.Areas.Admin.Models.ViewModels;
using NTierECommerce.MVC.AutoMappers;
using NTierECommerce.MVC.Models.ViewModels.MyOrder;

namespace NTierECommerce.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public OrderController(IOrderRepository orderRepository,IOrderDetailRepository orderDetailRepository,ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }
        public async Task<IActionResult> Index()
        {
            var getOrderList = _orderRepository.GetAll().Result;
            List<OrderVM> dashBoardVMs = new List<OrderVM>();
            foreach (var item in getOrderList.OrderByDescending(x => x.OrderDate))
            {
                dashBoardVMs.Add(new OrderVM
                {
                    OrderId = item.OrderId,
                    OrderDate = item.OrderDate,
                    TotalPrice = _orderDetailRepository.GetByOrderIDTotalPrice(item.OrderId).Result
                });
            }

            return View(dashBoardVMs);
        }

        public IActionResult Detail(int orderId)
        {
            var getOrder = _orderRepository.GetById(orderId).Result;
            var getOrderDetail = _orderDetailRepository.GetByIdList(orderId).Result;

            List<OrderDetailVM> orderDetailVM = new List<OrderDetailVM>();

            foreach(var item in getOrderDetail)
            {
                var getProduct = _productRepository.GetById(item.ProductId).Result;
                orderDetailVM.Add(new OrderDetailVM
                {
                    OrderId = orderId,
                    OrderDate = getOrder.OrderDate,
                    ProductName = getProduct.ProductName,
                    CategoryName = _categoryRepository.GetById(getProduct.CategoryId).Result.CategoryName,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    SubTotalPrice = item.UnitPrice * item.Quantity,
                    ImagePath = getProduct.ImagePath
                });
            }
            return View(orderDetailVM);
        }
    }
}
