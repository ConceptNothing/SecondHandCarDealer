using DataAccessLayer.Interfaces;
using Domain.Errorss;
using Domain.Models;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class CarsService : ICarsService
    {
        private readonly ICarRepository carRepository;
        public CarsService(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }
        public Task<Result<Car>> AddCar(Car car)
        {
            return carRepository.AddCar(car);
        }
        public Task<Result<Car>> UpdateCarIsSold(Car car)
        {
            return carRepository.UpdateCarIsSold(car);
        }
        public Task<Result<Car>> DeleteCar(Car car)
        {
            return carRepository.DeleteCar(car);
        }
        public Task<Result<Car>> GetCar(Car car)
        {
            return carRepository.GetCar(car);
        }

        public Task<Result<List<Car>>> GetAllCarsForSale()
        {
            return carRepository.GetAllCarsForSale();
        }
    }
}
