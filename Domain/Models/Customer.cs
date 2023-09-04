using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Domain.Extensions;

namespace Domain.Models
{
    public class Customer : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string CustomerType { get; set; }

        [NotMapped]
        public CustomerType CType
        {
            get => (CustomerType)Enum.Parse(typeof(CustomerType), CustomerType);
            set => CustomerType = value.GetDescription();
        }

        [Required]
        [JsonIgnore]
        public DateTime DbCreationDate { get; set; }
        [JsonIgnore]
        public DateTime? DbUpdateDate { get; set; }
        public LegalPerson? LegalPerson { get; set; }
        public NaturalPerson? NaturalPerson { get; set; }
        public Guid? LegalPersonId { get; set; }
        public Guid? NaturalPersonId { get; set; }
    }
}
