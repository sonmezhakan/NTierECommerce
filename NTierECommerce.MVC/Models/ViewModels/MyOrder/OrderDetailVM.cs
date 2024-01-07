namespace NTierECommerce.MVC.Models.ViewModels.MyOrder
{
    public class OrderDetailVM
    {
        private decimal _unitPrice;
        private decimal _subTotalPrice;

        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get { return _unitPrice; } set { _unitPrice = Math.Round(value, 2); } }
        public string ImagePath { get; set; }
        public decimal SubTotalPrice { get { return _subTotalPrice; } set { _subTotalPrice = Math.Round(value, 2); } }

        public DateTime OrderDate { get; set; }
    }
}
