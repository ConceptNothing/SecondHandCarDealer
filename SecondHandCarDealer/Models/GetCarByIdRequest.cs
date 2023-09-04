using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace SecondHandCarDealer.Models
{
    public class GetCarByIdRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}
