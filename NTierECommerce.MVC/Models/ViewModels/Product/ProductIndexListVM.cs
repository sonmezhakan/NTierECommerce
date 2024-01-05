namespace NTierECommerce.MVC.Models.ViewModels.Product
{
    public class ProductIndexListVM
    {
		private decimal _unitPrice;

		public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get { return _unitPrice; } set { _unitPrice = Math.Round(value, 2); } }
        public string ImagePath { get; set; }
    }
}
