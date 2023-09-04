using System.ComponentModel.DataAnnotations;

namespace SecondHandCarDealer.Models
{
    public class AddLegalPersonCustomerRequest
    {
        [Required]
        public string CompanyName { get; set; }

        [Required]
        public int RegistrationNumber { get; set; }
    }
}
