using Domain.Errorss;
using Domain.Models;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ICarRepository
    {
        Task<Result<Car>> AddCar(Car car);
        Task<Result<Car>> UpdateCarIsSold(Car car);
        Task<Result<Car>> DeleteCar(Car car);
        Task<Result<Car>> GetCar(Car car);
        Task<Result<List<Car>>> GetAllCarsForSale();
    }
}
