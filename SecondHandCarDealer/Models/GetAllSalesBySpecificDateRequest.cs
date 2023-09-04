using System.ComponentModel.DataAnnotations;

namespace SecondHandCarDealer.Models
{
    public class GetAllSalesBySpecificDateRequest
    {
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
