using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Core
{
    public class E_Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ItemPrice { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public string ProductImage { get; set; }
        public string ProductDescription { get; set; }


    }
}
