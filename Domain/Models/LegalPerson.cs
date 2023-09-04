using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models
{
    [Index(nameof(RegistrationNumber),IsUnique = true)]
    public class LegalPerson :IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public int RegistrationNumber { get; set; }
        [Required]
        [JsonIgnore]
        public DateTime DbCreationDate { get; set; }
        [JsonIgnore]
        public DateTime? DbUpdateDate { get; set; }
    }
}
