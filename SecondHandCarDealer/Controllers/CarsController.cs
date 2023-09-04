using AutoMapper;
using Domain.Errorss;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarDealer.Models;
using Service.Interfaces;
using System.Net;

namespace SecondHandCarDealer.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Produces("application/json")]
    public class CarsController : ControllerBase
    {
        private readonly ICarsService carsService;
        private readonly IMapper mapper;

        public CarsController(
            ICarsService carsService,
            IMapper mapper)
        {
            this.carsService = carsService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Adds a new car.
        /// </summary>
        /// <response code="200">Returns new posted Car.</response>
        /// <response code="400">If the Car already exists.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Car),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Car>> AddCar(AddCarRequest request)
        {
            var result = await carsService.AddCar(mapper.Map<Car>(request));

            if (result.HasError<CarIsDuplicate>())
            {
                ModelState.AddModelError(
                    request.Name,
                    "There is a car with same ID!"
                    );
                return ValidationProblem(ModelState);
            }

            return Ok(result.Value);
        }
        /// <summary>
        /// Gets a car.
        /// </summary>
        /// <response code="200">Returns found Car.</response>
        /// <response code="404">If the Car has not been found.</response>
        [HttpGet]
        [ProducesResponseType(typeof(Car), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Car>> GetCar([FromQuery] GetCarByIdRequest request)
        {
            var result = await carsService.GetCar(mapper.Map<Car>(request));
            if (result.HasError<CarNotFound>())
            {
                ModelState.AddModelError(
                    nameof(request.Id),
                    "Car has not been found!"
                    );
                return ValidationProblem(ModelState);
            }

            return Ok(result.Value);
        }
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Car>> DeleteCar([FromQuery] DeleteCarRequest request)
        {
            var result = await carsService.DeleteCar(mapper.Map<Car>(request));
            if (result.HasError<CarNotFound>())
            {
                ModelState.AddModelError(
                    nameof(request.Id),
                    "Car has not been found!"
                    );
                return ValidationProblem(ModelState);
            }
            return NoContent();
        }
        /// <summary>
        /// Gets all cars for sale.
        /// </summary>
        /// <response code="200">Returns found Car.</response>
        /// <response code="404">If the Cars for sale has not been found.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Car>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<List<Car>>> GetCarsForSale()
        {
            var result = await carsService.GetAllCarsForSale();
            if (result.HasError<CarNotFound>())
            {
                ModelState.AddModelError(
                    "CarsForSale",
                    "Cars for sale has not been found!"
                    );
                return ValidationProblem(ModelState);
            }

            return Ok(result.Value);
        }
    }
}
