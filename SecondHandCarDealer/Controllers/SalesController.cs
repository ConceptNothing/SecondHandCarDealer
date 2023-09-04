using AutoMapper;
using Domain.Errorss;
using Domain.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarDealer.Models;
using Service.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace SecondHandCarDealer.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Produces("application/json")]
    public class SalesController : ControllerBase
    {
        private readonly ICustomersService customersService;
        private readonly ISalesService saleseService;
        private readonly IMapper mapper;
        public SalesController(ICustomersService customersService,
            IMapper mapper,
            ISalesService saleseService)
        {
            this.customersService = customersService;
            this.mapper = mapper;
            this.saleseService = saleseService;
        }
        /// <summary>
        /// Adds a new Sale.
        /// Request contains Customer that should contain Id, if not then at least LegalPerson or NaturalPerson and Ctype
        /// If there is no customer in DB, app creates new customer based on Legal or Natural person
        /// </summary>
        /// <response code="200">Returns new posted sale.</response>
        /// <response code="400">If the Car or Customer does not exist/.</response>
        /// /// <response code="400">If car has already been sold/.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Sale), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Sale>> AddSale(AddSaleRequest request)
        {
            var result = await saleseService.AddSale(mapper.Map<Sale>(request));
            if (result.HasError<SaleIsDuplicate>())
            {
                ModelState.AddModelError(
                  nameof(request.CarId),
                  "Same sale already exist!"
                  );
                return ValidationProblem(ModelState);
            }
            if (result.HasError<CarNotFound>())
            {
                ModelState.AddModelError(
                  nameof(request.CarId),
                  "Car has not been found!"
                  );
                return ValidationProblem(ModelState);
            }
            if (result.HasError<CarAlreadySold>())
            {
                ModelState.AddModelError(
                  nameof(request.CarId),
                  "Car has been already sold!"
                  );
                return ValidationProblem(ModelState);
            }

            return Ok(result.Value);
        }
        /// <summary>
        /// Adds sales by specific date.
        /// </summary>
        /// <response code="200">Returns sales.</response>
        /// <response code="404">If theere are no sales this day/.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Sale>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<List<Sale>>> GetSalesByDate([FromQuery] [Required] DateTime request)
        {
            var result = await saleseService.GetSalesByDate(request);
            if (result.HasError<SalesNotFoundInSpecificDay>())
            {
                ModelState.AddModelError(
                 nameof(request.Date),
                 "SalesNotFoundInSpecificDay"
                 );
                return ValidationProblem(ModelState);
            }
            return Ok(result.Value);
        }
    }
}
