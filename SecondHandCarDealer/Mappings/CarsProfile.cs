using AutoMapper;
using Domain.Models;
using SecondHandCarDealer.Models;

namespace SecondHandCarDealer.Mappings
{
    public class CarsProfile : Profile
    {
        public CarsProfile() 
        {
            CreateMap<AddCarRequest, Car>();
            CreateMap<GetCarByIdRequest, Car>();
            CreateMap<DeleteCarRequest, Car>();
        }
    }
}
