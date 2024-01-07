namespace NTierECommerce.MVC.Models.ViewModels.MyOrder
{
	public class MyOrderListVM
	{
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string? ShipperName { get; set; }
        public string? ShipNumber { get; set; }
        public string? ShipStatus { get; set; }
    }
}
