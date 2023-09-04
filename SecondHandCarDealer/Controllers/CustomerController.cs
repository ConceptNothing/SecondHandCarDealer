using AutoMapper;
using Domain.Errorss;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarDealer.Models;
using Service.Implementations;
using System.ComponentModel.DataAnnotations;
using Service.Interfaces;
using System.Net;

namespace SecondHandCarDealer.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Produces("application/json")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomersService customersService;
        private readonly IMapper mapper;
        public CustomerController(ICustomersService customersService, IMapper mapper)
        {
            this.customersService = customersService;
            this.mapper = mapper;
        }
        /// <summary>
        /// Adds a new NaturalPerson customer.
        /// </summary>
        /// <response code="200">Returns new posted Customer.</response>
        /// <response code="400">If the Customer already exists.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Customer>> AddNaturalCustomer(AddNaturalPersonCustomerRequest request)
        {
            var result = await customersService.AddNaturalCustomer(mapper.Map<NaturalPerson>(request));

            if (result.HasError<NaturalPersonDoesNotExits>())
            {
                var addNaturalPersonResult = await customersService.AddNaturalPerson(mapper.Map<NaturalPerson>(request));
                result = await customersService.AddNaturalCustomer(addNaturalPersonResult.Value);
            }
            if(result.HasError<CustomerAlreadyExists>())
            {
                ModelState.AddModelError(
                    nameof(request.FirstName),
                    "Customer already exits!"
                    );
                return ValidationProblem(ModelState);
            }
            return Ok(result.Value);
        }
        /// <summary>
        /// Adds a new LegalPerson customer.
        /// </summary>
        /// <response code="200">Returns new posted Customer.</response>
        /// <response code="400">If the Customer already exists.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Customer>> AddLegalCustomer(AddLegalPersonCustomerRequest request)
        {
            var result = await customersService.AddLegalCustomer(mapper.Map<LegalPerson>(request));

            if (result.HasError<LegalPersonDoNotExits>())
            {
                var addLegalPersonResult = await customersService.AddLegalPerson(mapper.Map<LegalPerson>(request));
                result = await customersService.AddLegalCustomer(addLegalPersonResult.Value);
            }
            if (result.HasError<CustomerAlreadyExists>())
            {
                ModelState.AddModelError(
                    nameof(request.CompanyName),
                    "Customer already exits!"
                    );
                return ValidationProblem(ModelState);
            }
            return Ok(result.Value);
        }
    }
}
