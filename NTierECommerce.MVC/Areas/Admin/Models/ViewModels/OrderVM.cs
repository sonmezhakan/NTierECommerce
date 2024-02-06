namespace NTierECommerce.MVC.Areas.Admin.Models.ViewModels
{
    public class OrderVM
    {
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
