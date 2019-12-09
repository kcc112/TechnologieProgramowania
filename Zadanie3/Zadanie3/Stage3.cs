using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using Zadanie3.LinqToSql;

namespace Zadanie3
{
    public class Stage3
    {
        public static List<Product> GetProductsByName(string namePart)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                var output = from product in db.Products
                             where product.Name.Contains(namePart)
                             select product;

                return output.ToList();
            }
        }

        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                var output = from vendor in db.ProductVendors
                             where vendor.Vendor.Name.Equals(vendorName)
                             select vendor.Product;

                return output.ToList();
            }
        }

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                var output = from vendor in db.ProductVendors
                             where vendor.Vendor.Name.Equals(vendorName)
                             select vendor.Product.Name;

                return output.ToList();
            }
        }

        public static string GetProductVendorByProductName(string productName)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                var output = from vendor in db.ProductVendors
                             where vendor.Product.Name.Equals(productName)
                             select vendor.Vendor.Name;

                return output.FirstOrDefault();
            }
        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                var output = from product in db.Products
                             where product.ProductReviews.Count.Equals(howManyReviews)
                             select product;

                return output.ToList();
            }
        }

        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                var output = from product in db.Products
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
                var output = from product in db.Products
                             orderby product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                             select product;

                return output.Take(number).ToList();
            }
        }

        public static int GetTotalStandardCostByCategory(ProductCategory category)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                var output = from product in db.Products
                             where product.ProductSubcategory.ProductCategory.Name.Equals(category.Name)
                             select product.StandardCost;

                return (int)output.Sum();
            }
        }

        public static List<Product> GetProductsByNameExtend(string namePart)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                var output = db.Products.Where(product => product.Name.Contains(namePart));

                return output.ToList();
            }
        }

        public static List<Product> GetProductsByVendorNameExtend(string vendorName)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                var output = db.ProductVendors.Where(vendor => vendor.Vendor.Name.Equals(vendorName))
                                              .Select(vendor => vendor.Product);

                return output.ToList();
            }
        }

        public static List<string> GetProductNamesByVendorNameExtend(string vendorName)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                var output = db.ProductVendors.Where(vendor => vendor.Vendor.Name.Equals(vendorName))
                                              .Select(vendor => vendor.Product.Name);

                return output.ToList();
            }
        }

        public static string GetProductVendorByProductNameExtend(string productName)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                var output = db.ProductVendors.Where(vendor => vendor.Product.Name.Equals(productName))
                                              .Select(vendor => vendor.Vendor.Name);

                return output.FirstOrDefault();
            }
        }

        public static List<Product> GetProductsWithNRecentReviewsExtend(int howManyReviews)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                var output = db.Products.Where(product => product.ProductReviews.Count.Equals(howManyReviews));

                return output.ToList();
            }
        }

        public static List<Product> GetNRecentlyReviewedProductsExtend(int howManyProducts)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                var output = db.Products.Join(db.ProductReviews, product => product.ProductID, review => review.ProductID,
                                     (product, review) => new { Product = product, Review = review }).OrderByDescending(review => review.Review.ReviewDate)
                                     .Select(product => product.Product);

                return output.Take(howManyProducts).ToList();
            }
        }

        public static List<Product> GetNProductsFromCategoryExtend(string categoryName, int number)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                var output = db.Products.OrderBy(product => product.ProductSubcategory.ProductCategory.Name.Equals(categoryName));

                return output.Take(number).ToList();
            }
        }

        public static int GetTotalStandardCostByCategoryExtend(ProductCategory category)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                var output = db.Products.Where(product => product.ProductSubcategory.ProductCategory.Name.Equals(category.Name))
                                        .Select(product => product.StandardCost);

                return (int)output.Sum();
            }
        }
    }
}
