using DataAccessLayer.Interfaces;
using Domain.Errorss;
using Domain.Models;
using FluentResults;

namespace DataAccessLayer.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CarDealerDbContext dbContext;
        public CustomerRepository (CarDealerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Result<LegalPerson>> AddLegalPerson(LegalPerson person)
        {
            var result = dbContext.LegalPersons.Where(lp => lp.RegistrationNumber == person.RegistrationNumber).FirstOrDefault();
            if (result != null)
            {
                return Result.Fail(new LegalPersonAlreadyExists());
            }
            dbContext.LegalPersons.Add(person);
            await dbContext.SaveChangesAsync();
            return Result.Ok(person);
        }
        public async Task<Result<NaturalPerson>> AddNaturalPerson(NaturalPerson person)
        {
            var result = dbContext.NaturalPersons.FirstOrDefault(p=>p.Id== person.Id);
            if (result != null)
            {
                return Result.Fail(new NaturalPersonAlreadyExist());
            }
            dbContext.NaturalPersons.Add(person);
            await dbContext.SaveChangesAsync();
            return Result.Ok(person);
        }
        public async Task<Result<NaturalPerson>> GetNaturalPerson(NaturalPerson person)
        {
            var result = dbContext.NaturalPersons.FirstOrDefault(p=>p.Id== person.Id);
            if(result == null)
            {
                return Result.Fail(new NaturalPersonDoesNotExits());
            }
            return Result.Ok(result);
        }
        public async Task<Result<LegalPerson>> GetLegalPerson(LegalPerson person)
        {
            var result = dbContext.LegalPersons.FirstOrDefault(p=> p.Id == person.Id);
            if (result == null)
            {
                return Result.Fail(new LegalPersonDoNotExits());
            }
            return Result.Ok(result);
        }
        public async Task<Result<Customer>> AddLegalCustomer(LegalPerson customer)
        {
            var legalPerson = dbContext.LegalPersons.FirstOrDefault(lp => lp.RegistrationNumber == customer.RegistrationNumber);
            if (legalPerson == null)
            {
                return Result.Fail(new LegalPersonDoNotExits());
            }

            var customerResult = dbContext.Customers.Where(c=>c.LegalPersonId==legalPerson.Id).FirstOrDefault();
            if(customerResult != null)
            {
                return Result.Fail(new CustomerAlreadyExists());
            }

            Customer newCustomer = new Customer
            {
                CType = CustomerType.Legal,
                LegalPerson = legalPerson,
            };
            dbContext.Customers.Add(newCustomer);
            await dbContext.SaveChangesAsync();
            return Result.Ok(newCustomer);
        }

        public async  Task<Result<Customer>> AddNaturalCustomer(NaturalPerson customer)
        {
            var naturalPerson = dbContext.NaturalPersons.FirstOrDefault(p => p.Id == customer.Id);
            if (naturalPerson == null)
            {
                return Result.Fail(new NaturalPersonDoesNotExits());
            }

            var customerResult = dbContext.Customers.Where(c => c.NaturalPersonId == customer.Id).FirstOrDefault();
            if (customerResult != null)
            {
                return Result.Fail(new CustomerAlreadyExists());
            }
           
            Customer newCustomer = new Customer
            {
                CType = CustomerType.Natural,
                NaturalPerson = naturalPerson,
            };

            dbContext.Customers.Add(newCustomer);
            await dbContext.SaveChangesAsync();
            return Result.Ok(newCustomer);
        }

        public async Task<Result<Customer>> GetCustomer(Customer customer)
        {
            var result = dbContext.Customers.FirstOrDefault(c=>c.Id== customer.Id);
            if(result == null)
            {
                return Result.Fail(new CustomerNotFound());
            }
            return Result.Ok(result);
        }
        public async Task<Result<Customer>> GetCustomerByLegalPerson(LegalPerson person)
        {
            var result = dbContext.Customers.Where(c=>c.LegalPersonId == person.Id).FirstOrDefault();
            if(result == null)
            {
                return Result.Fail(new CustomerNotFound());
            }
            return Result.Ok(result);
        }
        public async Task<Result<Customer>> GetCustomerByNaturalPerson(NaturalPerson person)
        {
            var result = dbContext.Customers.Where(c => c.NaturalPersonId == person.Id).FirstOrDefault();
            if (result == null)
            {
                return Result.Fail(new CustomerNotFound());
            }

            return Result.Ok(result);
        }
    }
}
