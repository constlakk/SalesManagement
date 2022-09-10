using Microsoft.EntityFrameworkCore;
using SalesManagement.Models;

namespace SalesManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Salesman> Salesmen { get; set; }
        public DbSet<Sale> Sales { get; set; }
        
    }
}
