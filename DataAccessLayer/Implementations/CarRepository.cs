using DataAccessLayer.Interfaces;
using Domain.Errorss;
using Domain.Models;
using FluentResults;

namespace DataAccessLayer.Implementations
{
    public class CarRepository : ICarRepository
    {
        private readonly CarDealerDbContext dbContext;
        public CarRepository(CarDealerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result<Car>> AddCar(Car car)
        {
            var result = dbContext.Cars.Where(x => x.Id == car.Id).FirstOrDefault();
            if (result != null)
            {
                return Result.Fail(new CarIsDuplicate());
            }
            dbContext.Cars.Add(car);
            await dbContext.SaveChangesAsync();
            return Result.Ok(car);
        }
        public async Task<Result<Car>> UpdateCarIsSold(Car car)
        {
            var result = dbContext.Cars.Where(c => c.Id == car.Id).FirstOrDefault();
            if (result == null)
            {
                return Result.Fail(new CarNotFound());
            }
            result.IsSold = car.IsSold;
            await dbContext.SaveChangesAsync();
            return Result.Ok(car);
        }
        public async Task<Result<Car>> DeleteCar(Car car)
        {
            var result = dbContext.Cars.Where(c => c.Id == car.Id).FirstOrDefault();
            if (result == null)
            {
                return Result.Fail(new CarNotFound());
            }

            dbContext.Cars.Remove(result);
            await dbContext.SaveChangesAsync();
            return Result.Ok(car);
        }
        public async Task<Result<Car>> GetCar(Car car)
        {
            var result = dbContext.Cars.Where(c=>c.Id==car.Id).FirstOrDefault();
            if (result == null)
            {
                return Result.Fail(new CarNotFound());
            }
            return Result.Ok(result);
        }
        public async Task<Result<List<Car>>> GetAllCarsForSale()
        {
            var result = dbContext.Cars.Where(c=>c.IsSold == false).ToList();
            if (result.Count == 0)
            {
                /// NOT AVAIBLE CARs for sale but im lazy
                return Result.Fail(new CarNotFound());
            }
            return Result.Ok(result);
        }
    }
}
