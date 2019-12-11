using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie3.LinqToSql;



namespace Zadanie3.LinqToSql
{

    public class MyProduct : Product
    {

        public MyProduct(Product product)
        {
            Name = product.Name;
            ProductID = product.ProductID;
            ProductReviews = product.ProductReviews;
            ProductSubcategory = product.ProductSubcategory;
            ProductSubcategoryID = product.ProductSubcategoryID;
        }

        public static List<MyProduct> GetMyProductByName(string namePart)
        {
            var output = from product in MyProductRepository.myProducts
                         where product.Name.Contains(namePart)
                         select product;

            return output.ToList();
        }

        public static List<MyProduct> GetProductsWithNRecentReviews(int howManyReviews)
        {
            var output = from product in MyProductRepository.myProducts
                         where product.ProductReviews.Count.Equals(howManyReviews)
                         select product;

            return output.ToList();
        }

        public static List<MyProduct> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                var output = from product in MyProductRepository.myProducts
                             join review in db.ProductReviews on product.ProductID equals review.ProductID
                             orderby review.ReviewDate descending
                             select product;

                return output.Take(howManyProducts).ToList();
            }
        }
    }
}
