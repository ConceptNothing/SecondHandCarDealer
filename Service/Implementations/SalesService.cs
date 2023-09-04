using DataAccessLayer.Interfaces;
using Domain.Errorss;
using Domain.Models;
using FluentResults;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository salesRepository;
        private readonly ICustomersService customerService;
        public SalesService(ISalesRepository salesRepository,
            ICustomersService customerService)
        {
            this.salesRepository = salesRepository;
            this.customerService = customerService;
        }

        public async Task<Result<Sale>> AddSale(Sale sale)
        {
            var foundCustomer = await customerService.GetCustomer(sale.Customer);
            if (!foundCustomer.IsSuccess)
            {
                if(sale.Customer.CType == CustomerType.Natural && sale.Customer.NaturalPerson!=null)
                {
                    Customer customerToCreate = new Customer();
                    //Ar fi nice validation.....
                    var getNaturalPersonResult = customerService.GetNaturalPerson(sale.Customer.NaturalPerson);
                    if(getNaturalPersonResult.Result.IsSuccess) 
                    {
                        var createCustomerExistingPerson = await customerService.AddNaturalCustomer(getNaturalPersonResult.Result.Value);
                        if (createCustomerExistingPerson.HasError<CustomerAlreadyExists>())
                        {
                            var getCustomer = customerService.GetCustomerByNaturalPerson(sale.Customer.NaturalPerson);
                            sale.Customer = getCustomer.Result.Value;
                        }
                        else
                        {
                            sale.Customer = createCustomerExistingPerson.Value;
                        }
                    }
                    else
                    {
                        var createNaturalPerson = await customerService.AddNaturalPerson(sale.Customer.NaturalPerson);
                        var createCustomer = await customerService.AddNaturalCustomer(createNaturalPerson.Value);
                        sale.Customer = createCustomer.Value;
                    }
                }
                if(sale.Customer.CType == CustomerType.Legal && sale.Customer.LegalPerson != null)
                {
                    Customer customerToCreate = new Customer();

                    var getLegalPersonResult = customerService.GetLegalPerson(sale.Customer.LegalPerson);
                    if (getLegalPersonResult.Result.IsSuccess)
                    {

                        var createCustomerExistingPerson = await customerService.AddLegalCustomer(getLegalPersonResult.Result.Value);
                        if (createCustomerExistingPerson.HasError<CustomerAlreadyExists>())
                        {
                            var getCustomer = customerService.GetCustomerByLegalPerson(sale.Customer.LegalPerson);
                            sale.Customer = getCustomer.Result.Value;
                        }
                        else
                        {
                            sale.Customer = createCustomerExistingPerson.Value;
                        }
                        sale.Customer = createCustomerExistingPerson.Value;
                    }
                    else
                    {
                        var createNaturalPerson = await customerService.GetLegalPerson(sale.Customer.LegalPerson);
                        var createCustomer = await customerService.AddLegalCustomer(createNaturalPerson.Value);
                        sale.Customer = createCustomer.Value;
                    }
                }
            }
            return await salesRepository.AddSale(sale);
        }

        public Task<Result<List<Sale>>> GetAllSales()
        {
            return salesRepository.GetAllSales();
        }

        public Task<Result<List<Sale>>> GetSalesByDate(DateTime targetDate)
        {
            return salesRepository.GetSalesByDate(targetDate);
        }
    }
}
