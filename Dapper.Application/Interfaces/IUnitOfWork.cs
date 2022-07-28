using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository E_Product { get; }
        IOrderRepository E_Order { get; }
    }
}
