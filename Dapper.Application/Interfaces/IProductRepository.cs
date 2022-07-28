using Dapper.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Application.Interfaces
{
    public interface IProductRepository : IGenericRepository<E_Product>
    {
        Task<IEnumerable<E_Product>> GetByFilterAsync(int categoryId, int sizeId, int colorId);
    }
}
