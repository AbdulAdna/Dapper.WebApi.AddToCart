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
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration configuration;
        public ProductRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(E_Product entity)
        {
            //entity.AddedOn = DateTime.Now;
            var sql = "INSERT INTO [dbo].[E_Product] ([ProductName],[ItemPrice],[CategoryId],[ColorId],[SizeId],[ProductImage] VALUES (@ProductName,@ItemPrice,@CategoryId,@ColorId,@SizeId,@ProductImage)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
        public async Task<int> DeleteAsync(int productId)
        {
            var sql = "DELETE FROM E_Product WHERE ProductId = @ProductId";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { ProductId = productId });
                return result;
            }
        }
        public async Task<IReadOnlyList<E_Product>> GetAllAsync()
        {
            var sql = "SELECT * FROM V_Product";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<E_Product>(sql);
                return result.ToList();
            }
        }
        public async Task<E_Product> GetByIdAsync(int productId)
        {
            var sql = "SELECT * FROM E_Product WHERE ProductId = @ProductId";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<E_Product>(sql, new { ProductId = productId });
                return result;
            }
        }

        public async Task<IEnumerable<E_Product>> GetByFilterAsync(int categoryId, int sizeId, int colorId)
        {
            var sql = "";

            string filter = "";

            if (categoryId != -1 && categoryId != 0)
            {
                if (filter != "")
                {
                    filter += $" AND CategoryId = '{categoryId}' ";
                }
                else
                {
                    filter += $" CategoryId = '{categoryId}' ";
                }
            }

            if (sizeId != -1 && sizeId != 0)
            {
                if (filter != "")
                {
                    filter += $" AND SizeId = '{sizeId}' ";
                }
                else
                {
                    filter += $" SizeId = '{sizeId}' ";
                }
            }

            if (colorId != -1 && colorId != 0)
            {
                if (filter != "")
                {
                    filter += $" AND ColorId = '{colorId}' ";
                }
                else
                {
                    filter += $" ColorId = '{colorId}' ";
                }
            }

            if (filter == "")
            {
                sql = $@"SELECT * FROM V_Product";
            }
            else
            {
                sql = $@"SELECT * FROM V_Product WHERE {filter}";
            }

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<E_Product>(sql, new { CategoryId = categoryId, SizeId = sizeId, ColorId = colorId});
                return result;
            }
        }
        public async Task<int> UpdateAsync(E_Product entity)
        {
            //entity.ModifiedOn = DateTime.Now;
            var sql = "UPDATE [dbo].[E_Product] SET [ProductName] = @ProductName, [ItemPrice] = @ItemPrice, [CategoryId] = @CategoryId, [ColorId] = @ColorId, [SizeId] = @SizeId, [ProductImage] = @ProductImage WHERE ProductId = @ProductId";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }


    }
}
