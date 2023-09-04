using System.ComponentModel.DataAnnotations;

namespace SecondHandCarDealer.Models
{
    public class AddCarRequest
    {
        [Required]
        public string Model { get; set;}
        [Required]
        public string Name { get; set;}
        [Required]
        public string Description { get; set;}
        [Required]
        public int Price { get; set;}
        [Required]
        public CarCategory CarCategory { get; set;}
        [Required]
        public int Year { get; set; }
    }
}
