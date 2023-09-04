using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Domain.Extensions;

namespace Domain.Models
{

    public class Car : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50)]
        public string Category { get; set; }
        [NotMapped]
        [JsonIgnore]
        public CarCategory CarCategory
        {
            get=> (CarCategory)Enum.Parse(typeof(CarCategory), Category);
            set => Category = value.GetDescription();
        }
        [Required]
        public int Year { get; set; }
        public bool? IsSold { get; set; } = false;
        [JsonIgnore]
        [Required]
        public DateTime DbCreationDate { get; set; }
        [JsonIgnore]
        public DateTime? DbUpdateDate { get; set; }
    }
}
