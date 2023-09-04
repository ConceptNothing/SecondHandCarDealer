using Domain.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ISalesService
    {
        Task<Result<Sale>> AddSale(Sale sale);
        Task<Result<List<Sale>>> GetAllSales();
        Task<Result<List<Sale>>> GetSalesByDate(DateTime targetDate);
    }
}
