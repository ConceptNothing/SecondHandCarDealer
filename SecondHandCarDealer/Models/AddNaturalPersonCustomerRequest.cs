using System.ComponentModel.DataAnnotations;

namespace SecondHandCarDealer.Models
{
    public class AddNaturalPersonCustomerRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
