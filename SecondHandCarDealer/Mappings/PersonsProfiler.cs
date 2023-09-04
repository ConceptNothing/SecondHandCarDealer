using AutoMapper;
using Domain.Models;
using SecondHandCarDealer.Models;

namespace SecondHandCarDealer.Mappings
{
    public class PersonsProfiler :Profile
    {
        public PersonsProfiler()
        {
            CreateMap<AddNaturalPersonCustomerRequest, NaturalPerson>();
            CreateMap<AddLegalPersonCustomerRequest, LegalPerson>();
        }
    }
}
