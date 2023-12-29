namespace NTierECommerce.MVC.Areas.Admin.Models.ViewModels
{
    public class ProductVM
    {
        private decimal _unitPrice;

        public int ID { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get { return _unitPrice; } set { _unitPrice = Math.Round(value, 2); } }
        public int UnitsInStock { get; set; }
        public bool IsActive { get; set; }
        public string? ImagePath { get; set; }
    }
}
