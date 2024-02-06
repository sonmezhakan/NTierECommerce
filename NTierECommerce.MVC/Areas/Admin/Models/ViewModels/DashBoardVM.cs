namespace NTierECommerce.MVC.Areas.Admin.Models.ViewModels
{
    public class DashBoardVM
    {
        public int TotalOrderCount { get; set; }
        public int MonthlyOrderCount{ get; set; }
        public decimal TotalEarning { get; set; }
        public int AppUserCount { get; set; }
        public List<OrderVM> DashBoardOrders { get; set; }
    }
}
