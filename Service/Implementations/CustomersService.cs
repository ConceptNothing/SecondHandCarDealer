using DataAccessLayer.Interfaces;
using Domain.Models;
using FluentResults;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomerRepository customerRepository;
        public CustomersService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Task<Result<Customer>> AddNaturalCustomer(NaturalPerson person)
        {
            return customerRepository.AddNaturalCustomer(person);
        }

        public Task<Result<Customer>> AddLegalCustomer(LegalPerson person)
        {
            return customerRepository.AddLegalCustomer(person);
        }

        public Task<Result<NaturalPerson>> AddNaturalPerson(NaturalPerson person)
        {
            return customerRepository.AddNaturalPerson(person);
        }

        public Task<Result<LegalPerson>> AddLegalPerson(LegalPerson person)
        {
            return customerRepository.AddLegalPerson(person);
        }

        public Task<Result<Customer>> GetCustomer(Customer customer)
        {
            return customerRepository.GetCustomer(customer);
        }

        public Task<Result<LegalPerson>> GetLegalPerson(LegalPerson person)
        {
            return customerRepository.GetLegalPerson(person);
        }

        public Task<Result<NaturalPerson>> GetNaturalPerson(NaturalPerson person)
        {
            return customerRepository.GetNaturalPerson(person);
        }
        public Task<Result<Customer>> GetCustomerByLegalPerson(LegalPerson person)
        {
            return customerRepository.GetCustomerByLegalPerson(person);
        }
        public Task<Result<Customer>> GetCustomerByNaturalPerson(NaturalPerson person)
        {
            return customerRepository.GetCustomerByNaturalPerson(person);
        }
    }
}
