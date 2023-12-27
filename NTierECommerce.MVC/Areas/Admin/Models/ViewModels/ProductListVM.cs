﻿namespace NTierECommerce.MVC.Areas.Admin.Models.ViewModels
{
    public class ProductListVM
    {
        private decimal _unitPrice;

        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get { return _unitPrice; } set { _unitPrice = Math.Round(value, 2); } }
        public bool IsActive { get; set; }
    }
}