using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3.LinqToSql
{
    public partial class ProductionDataContext
    {
        public List<Product> GetFirstNProducts(int number)
        {
            var output = from product in Products
                         select product;

            return output.Take(number).ToList();
        }

        public List<ProductVendor> GetFirstNProductVendor(int number)
        {
            var output = from vendor in ProductVendors
                         select vendor;

            return output.Take(number).ToList();
        }
    }
}
