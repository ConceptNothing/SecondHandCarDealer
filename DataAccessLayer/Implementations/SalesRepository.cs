using DataAccessLayer.Interfaces;
using Domain.Errorss;
using Domain.Models;
using FluentResults;

namespace DataAccessLayer.Implementations
{
    public class SalesRepository : ISalesRepository
    {
        private readonly CarDealerDbContext dbContext;
        public SalesRepository(CarDealerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result<Sale>> AddSale(Sale sale)
        {
            var saleResult = dbContext.Sales.Where(s=>s.CarId==sale.CarId && s.CustomerId == sale.CustomerId).FirstOrDefault();
            if(saleResult != null)
            {
                return Result.Fail(new SaleIsDuplicate());
            }

            var car = dbContext.Cars.Where(c => c.Id ==sale.CarId).FirstOrDefault();
            if(car == null)
            {
                return Result.Fail(new CarNotFound());
            }

            var isCarSold = car.IsSold;
            if (isCarSold.Value)
            {
                return Result.Fail(new CarAlreadySold());
            }

            var customer = dbContext.Customers.Where(c => c.Id==sale.Customer.Id).FirstOrDefault();
            if(customer == null)
            {
                return Result.Fail(new CustomerNotFound());
            }
            car.IsSold = true;
            sale.Car = car;
            sale.Customer = customer;
            dbContext.Sales.Add(sale);
            await dbContext.SaveChangesAsync();
            return Result.Ok(sale);
        }

        public async Task<Result<List<Sale>>> GetAllSales()
        {
            // this is bad approach, but for this small app i'm too lazy to make pagination or 
            var result = dbContext.Sales.ToList();

            return result;
        }
        public async Task<Result<List<Sale>>> GetSalesByDate(DateTime targetDate)
        {
            var salesOnTargetDate = dbContext.Sales
                .Where(s => s.DbCreationDate.Date == targetDate.Date)
                .ToList();
            if (salesOnTargetDate.Count < 0)
            {
                return Result.Fail(new SalesNotFoundInSpecificDay());
            }
            return Result.Ok(salesOnTargetDate);

        }
    }
}
