using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace SecondHandCarDealer.Models
{
    public class AddSaleRequest
    {
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public Guid CarId { get; set; }
    }
}
