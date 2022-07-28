using Dapper.Application.Interfaces;
using Dapper.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IConfiguration configuration;
        public OrderRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }





        public async Task<int> AddAsync(E_Order entity)
        {
            //entity.AddedOn = DateTime.Now;
            var sql = "INSERT INTO [dbo].[E_Order] ([ProductId] ,[Quantity] ,[Total]) VALUES (@ProductId, @Quantity, @Total)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task AddListAsync(List<E_Order> entity)
        {

            //entity.AddedOn = DateTime.Now;
            var sql = "INSERT INTO [dbo].[E_Order] ([ProductId] ,[Quantity] ,[Total]) VALUES (@ProductId, @Quantity, @Total)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {

                for (int i = 0; i < entity.Count; i++)
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@ProductId", entity[i].ProductId);
                    parameters.Add("@Quantity", entity[i].Quantity);
                    parameters.Add("@Total", entity[i].Total);

                    var result = await connection.ExecuteAsync(sql, parameters);

                }
            }
        }

        public async Task<int> DeleteAsync(int orderId)
        {
            var sql = "DELETE FROM E_Order WHERE OrderId = @OrderId";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { OrderId = orderId });
                return result;
            }
        }
        public async Task<IReadOnlyList<E_Order>> GetAllAsync()
        {
            var sql = "SELECT * FROM E_Order";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<E_Order>(sql);
                return result.ToList();
            }
        }
        public async Task<E_Order> GetByIdAsync(int orderId)
        {
            var sql = "SELECT * FROM E_Order WHERE OrderId = @OrderId";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<E_Order>(sql, new { OrderId = orderId });
                return result;
            }
        }
        public async Task<int> UpdateAsync(E_Order entity)
        {
            //entity.ModifiedOn = DateTime.Now;
            var sql = "UPDATE [dbo].[E_Order] SET [ProductId] = @ProductId, [Quantity] = @Quantity, [Total] = @Total WHERE OrderId = @OrderId";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }


    }
}
