using SalesManagement.Models;

namespace SalesManagement.ViewModels
{
    public class SalesmanDetailsVM
    {
        public Salesman Salesman { get; set; }
        public List<SaleVM> Sales { get; set; }
    }
}
