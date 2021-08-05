using DiscountAPI.Models;
using DiscountAPI.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountAPI.Services
{
    public interface IDiscountService
    {
        Task<Response<List<Discount>>> GetAll();
        Task<Response<Discount>> GetById(int id);
        Task<Response<NoContent>> Save(Discount discount);
        Task<Response<NoContent>> Update(Discount discount);
        Task<Response<NoContent>> Delete(int id);
    }
}
