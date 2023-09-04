using System.ComponentModel.DataAnnotations;

namespace SecondHandCarDealer.Models
{
    public class DeleteCarRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}
