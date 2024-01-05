namespace NTierECommerce.MVC.Models
{
    public class CartItem
    {
        public CartItem()
        {
            Quantity = 1;
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal? Subtotal { get { return Quantity * UnitPrice; } }
    }
}
