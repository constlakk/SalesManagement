using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesManagement.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [DisplayName("Sale Date")]
        public DateTime SaleDate { get; set; } 
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal Commission { get; private set; }
        [Required]
        [DisplayName("Salesman")]
        public int SalesmanId { get; set; }
        [ForeignKey("SalesmanId")]
        [ValidateNever]
        public Salesman Salesman { get; set; }
    }
}
