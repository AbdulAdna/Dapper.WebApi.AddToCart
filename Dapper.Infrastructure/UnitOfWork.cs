using Dapper.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            E_Product = productRepository;
            E_Order = orderRepository;
        }
        public IProductRepository E_Product { get; }
        public IOrderRepository E_Order { get; }

    }
}
