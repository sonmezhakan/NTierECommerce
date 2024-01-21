using AutoMapper;
using NTierECommerce.Entities.Entities;
using NTierECommerce.MVC.Areas.Admin.Models.ViewModels;
using NTierECommerce.MVC.Models;
using NTierECommerce.MVC.Models.ViewModels;
using NTierECommerce.MVC.Models.ViewModels.Category;
using NTierECommerce.MVC.Models.ViewModels.MyCart;
using NTierECommerce.MVC.Models.ViewModels.MyOrder;
using NTierECommerce.MVC.Models.ViewModels.Product;

namespace NTierECommerce.MVC.AutoMappers
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            #region CategoryMapper
            CreateMap<Category, CategoryVM>();
            CreateMap<CategoryVM, Category>();

            CreateMap<Category, CategoryListVM>();
            CreateMap<CategoryListVM, Category>();

            CreateMap<Category, CategoryIndexListVM>();
            CreateMap<CategoryIndexListVM, Category>();

            #endregion
            #region ProductMapper
            CreateMap<Product, ProductVM>();
            CreateMap<ProductVM, Product>();

            CreateMap<Product, ProductDetailVM>();
            CreateMap<ProductDetailVM, Product>();

            CreateMap<Product, ProductIndexListVM>();
            CreateMap<ProductIndexListVM, Product>();

            CreateMap<Product, ProductDetailVM>();
            CreateMap<ProductDetailVM, Product>();

            #endregion

            #region OrderMapper
            CreateMap<Order, MyOrderListVM>();
            CreateMap<MyOrderListVM, Order>();
            #endregion

            #region OrderDetailMapper
            CreateMap<OrderDetail, OrderDetailVM>();
            CreateMap<OrderDetailVM, OrderDetail>();

            CreateMap<OrderDetail, Cart>();
            CreateMap<Cart, OrderDetail>();
            #endregion

            #region ShipperMapper
            #endregion

            #region ShippingAddressMapper
            CreateMap<ShippingAddress, ShippingAddressVM>();
            CreateMap<ShippingAddressVM, ShippingAddress>();
            #endregion

            #region AppUser
            CreateMap<AppUser, LoginVM>();
            CreateMap<LoginVM, AppUser>();

            CreateMap<AppUser,UserRegisterVM>();
            CreateMap<UserRegisterVM, AppUser>();

            CreateMap<AppUser, UserListVM>();
            CreateMap<UserListVM, AppUser>();

            CreateMap<AppUser, UserUpdateVM>();
            CreateMap<UserUpdateVM, AppUser>();
            #endregion
            #region AppUserRole
            CreateMap<AppUserRole, AppUserRoleVM>();
            CreateMap<AppUserRoleVM, AppUserRole>();

            CreateMap<AppUserRole, AppUserRoleListVM>();
            CreateMap<AppUserRoleListVM, AppUserRole>();
            #endregion
            #region Cart
            CreateMap<CartItem, Product>();
            CreateMap<Product, CartItem>();
            #endregion
        }
    }
}
