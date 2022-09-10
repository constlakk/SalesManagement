using SalesManagement.Models;

namespace SalesManagement.ViewModels
{
    public class SalesmanVM
    {
        public List<Salesman> Salesmen { get; set; }
        public List<Sale> Sales { get; set; }
        public List<CommissionVM> Commissions { get; set; }
    }
}
