using AutoMapper;
using NTierECommerce.Entities.Entities;
using NTierECommerce.MVC.Areas.Admin.Models.ViewModels;
using NTierECommerce.MVC.Models;
using NTierECommerce.MVC.Models.ViewModels;
using NTierECommerce.MVC.Models.ViewModels.Category;
using NTierECommerce.MVC.Models.ViewModels.MyCart;
using NTierECommerce.MVC.Models.ViewModels.MyOrder;
using NTierECommerce.MVC.Models.ViewModels.Product;
using NTierECommerce.BLL.Abstracts;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace NTierECommerce.MVC.AutoMappers
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            #region CategoryMapper
            CreateMap<Category, CategoryVM>().ReverseMap();

            CreateMap<Category, CategoryListVM>().ReverseMap();

            CreateMap<Category, CategoryIndexListVM>().ReverseMap();

            #endregion
            #region ProductMapper
            CreateMap<Product, ProductVM>().ReverseMap();

            CreateMap<Product, ProductDetailVM>().ReverseMap();

            CreateMap<Product, ProductIndexListVM>().ReverseMap();

            CreateMap<Product, ProductDetailVM>().ReverseMap();

            #endregion

            #region OrderMapper
            CreateMap<Order, MyOrderListVM>().ReverseMap();

            #endregion

            #region OrderDetailMapper
            CreateMap<OrderDetail, OrderDetailVM>().ReverseMap();

            CreateMap<OrderDetail, Cart>().ReverseMap();

            #endregion

            #region ShipperMapper
            CreateMap<Shipper, ShipperVM>().ReverseMap();

            #endregion

            #region ShippingAddressMapper
            CreateMap<ShippingAddress, ShippingAddressVM>().ReverseMap();

            #endregion

            #region AppUser
            CreateMap<AppUser, LoginVM>().ReverseMap();

            CreateMap<AppUser, UserRegisterVM>().ReverseMap();

            CreateMap<AppUser, UserListVM>().ReverseMap();

            CreateMap<AppUser, UserUpdateVM>().ReverseMap();

            #endregion
            #region AppUserRole
            CreateMap<AppUserRole, AppUserRoleVM>().ReverseMap();

            CreateMap<AppUserRole, AppUserRoleListVM>().ReverseMap();

            #endregion
            #region Cart
            CreateMap<CartItem, Product>().ReverseMap();
            
            #endregion
        }
    }
    
}
