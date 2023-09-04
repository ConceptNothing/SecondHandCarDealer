using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Sale : IEntity
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid CarId { get; set; }
        [Required]
        public Car Car { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public DateTime DbCreationDate { get; set; }
        [JsonIgnore]
        public DateTime? DbUpdateDate { get; set; }
    }
}
