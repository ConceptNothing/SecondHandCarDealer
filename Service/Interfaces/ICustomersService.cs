using Domain.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICustomersService
    {
        Task<Result<Customer>> AddNaturalCustomer(NaturalPerson person);
        Task<Result<Customer>> AddLegalCustomer(LegalPerson person);
        Task<Result<NaturalPerson>> AddNaturalPerson(NaturalPerson person);
        Task<Result<LegalPerson>> AddLegalPerson(LegalPerson person);
        Task<Result<Customer>> GetCustomer(Customer customer);
        Task<Result<LegalPerson>> GetLegalPerson(LegalPerson person);
        Task<Result<NaturalPerson>> GetNaturalPerson(NaturalPerson person);
        Task<Result<Customer>> GetCustomerByLegalPerson(LegalPerson person);
        Task<Result<Customer>> GetCustomerByNaturalPerson(NaturalPerson person);
    }
}
