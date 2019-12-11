using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zadanie3.LinqToSql;

namespace Zadanie3
{
    public static class Stage4
    {
        #region Declarative - used from
        public static List<Product> GetProductsWithoutCategoryDeclarative(this List<Product> products)
        {
            var output = from product in products
                         where product.ProductSubcategory == null
                         select product;

            return output.ToList();
        }

        public static List<Product> SplitToPagesDeclarative(this List<Product> products, int size, int pageNumber)
        {
            var output = from product in products
                         select product;

            return output.Skip((pageNumber - 1) * size).Take(size).ToList();
        }

        public static string ChangeToStringDeclarative(this List<Product> products, List<ProductVendor> productVendors)
        {

            StringBuilder stringBuilder = new StringBuilder();

            var productsAndVendors = from product in products
                                     from productVendor in productVendors
                                     where productVendor.ProductID == product.ProductID
                                     select new { Product = product.Name, Vendor = productVendor.Vendor.Name };

            foreach (var productAndVendor in productsAndVendors)
            {
                stringBuilder.AppendLine(productAndVendor.Product + "-" + productAndVendor.Vendor);
            }
            return stringBuilder.ToString();
        }
        #endregion

        #region Imperative - used Extension Methods
        public static List<Product> GetProductsWithoutCategoryImperativ(this List<Product> products)
        {
            return products.Where(p => p.ProductSubcategory == null).ToList();
        }

        public static List<Product> SplitToPagesImperativ(this List<Product> products, int size, int pageNumber)
        {
            return products.Skip((pageNumber - 1) * size).Take(size).ToList();
        }

        public static string ChangeToStringImperativ(this List<Product> products, List<ProductVendor> productVendors)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var productsAndVendors = products.Join(productVendors, product => product.ProductID, vendor => vendor.ProductID, (product, productVendor) => new { Product = product.Name, Vendor = productVendor.Vendor.Name });

            foreach (var productAndVendor in productsAndVendors)
            {
                stringBuilder.AppendLine(productAndVendor.Product + "-" + productAndVendor.Vendor);
            }
            return stringBuilder.ToString();
        }
        #endregion
    }
}
