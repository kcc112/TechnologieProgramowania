using DataLayer.SqlConnection;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class Query
    {
        public static List<Product> GetProductsByName(string namePart)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                IQueryable<Product> output = from product in db.Products
                                             where product.Name.Contains(namePart)
                                             select product;

                return output.ToList();
            }
        }

        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                IQueryable<Product> output = from vendor in db.ProductVendors
                                             where vendor.Vendor.Name.Equals(vendorName)
                                             select vendor.Product;

                return output.ToList();
            }
        }

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                IQueryable<string> output = from vendor in db.ProductVendors
                                            where vendor.Vendor.Name.Equals(vendorName)
                                            select vendor.Product.Name;

                return output.ToList();
            }
        }

        public static string GetProductVendorByProductName(string productName)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                IQueryable<string> output = from vendor in db.ProductVendors
                                             where vendor.Product.Name.Equals(productName)
                                             select vendor.Vendor.Name;

                return output.FirstOrDefault();
            }
        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                IQueryable<Product> output = from product in db.Products
                                            where product.ProductReviews.Count.Equals(howManyReviews)
                                            select product;

                return output.ToList();
            }
        }

        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                IQueryable<Product> output = from product in db.Products
                                             join review in db.ProductReviews on product.ProductID equals review.ProductID
                                             orderby review.ReviewDate descending
                                             select product;

                return output.Take(howManyProducts).ToList();
            }
        }

        public static List<Product> GetNProductsFromCategory(string categoryName, int number)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                IQueryable<Product> output = from product in db.Products
                                             orderby product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                                             select product;

                return output.Take(number).ToList();
            }
        }

        public static int GetTotalStandardCostByCategory(ProductCategory category)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                IQueryable<decimal> output = from product in db.Products
                                             where product.ProductSubcategory.ProductCategory.Name.Equals(category.Name)
                                             select product.StandardCost;

                return (int)output.Sum();
            }
        }
    }
}