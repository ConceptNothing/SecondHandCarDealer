using AutoMapper;
using Domain.Models;
using SecondHandCarDealer.Models;

namespace SecondHandCarDealer.Mappings
{
    public class SalesProfiler : Profile
    {
        public SalesProfiler()
        {
            CreateMap<AddSaleRequest, Sale>();
            CreateMap<GetAllSalesBySpecificDateRequest, DateTime>();
        }
    }
}
