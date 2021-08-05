using Dapper;
using DiscountAPI.Models;
using DiscountAPI.Response;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountAPI.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IConfiguration _configuration;  // appsetting dosyalarını okumak için
        private readonly IDbConnection _dbConnection;  //veri tabanına bağlanmak için

        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }

        public async Task<Response<NoContent>> Delete(int id)
        {
            var status = await _dbConnection.ExecuteAsync("delete from discount where id=@Id",new { Id = id});
            if (status > 0)
            {
                return Response<NoContent>.Success(204);
            }
            return Response<NoContent>.Fail("an error occurred while adding", 500);
        }

        public async Task<Response<List<Discount>>> GetAll()
        {
            var discount = await _dbConnection.QueryAsync<Discount>("select * from discount");
            return Response<List<Discount>>.Success(discount.ToList(), 200);
        }

        public async Task<Response<Discount>> GetById(int id)
        {
            var discount = (await _dbConnection.QueryAsync<Discount>("select * from discount where id = @Id", new { Id = id }))
                .SingleOrDefault();
            if (discount == null)
            {
                return Response<Discount>.Fail("Discount not fount", 404);
            }
            return Response<Discount>.Success(discount, 200);
        }

        public async Task<Response<NoContent>> Save(Discount discount)
        {
            var status = await _dbConnection.ExecuteAsync("insert into discount (userid,rate,code) values(@UserId,@Rate,@Code)",
                discount);
            if (status > 0)
            {
                return Response<NoContent>.Success(204);
            }
            return Response<NoContent>.Fail("an error occurred while adding", 500);
        }

        public async Task<Response<NoContent>> Update(Discount discount)
        {
            var status = await _dbConnection.ExecuteAsync("update from discount set userid=@UserId,code = @Code,rate = @Rate",
                discount);
            if (status > 0)
            {
                return Response<NoContent>.Success(204);
            }
            return Response<NoContent>.Fail("an error occurred while update", 500);
        }
    }
}
//Dapper = > sorgulamada query , add update ise execute denir