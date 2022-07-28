using Dapper.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Application.Interfaces
{
    public interface IOrderRepository:IGenericRepository<E_Order>
    {
        Task AddListAsync(List<E_Order> entity);
    }
}
