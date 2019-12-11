using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;
using Zadanie3.LinqToSql;
using static Zadanie3.LinqToSql.ProductionDataContext;

namespace Tests
{
    [TestClass]
    public class MyProductTest
    {
        [TestMethod]
        public void GetMyProductByNameTest()
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                List<Product> productList = db.GetFirstNProducts(20);

                foreach(Product product in productList)
                {
                    MyProductRepository.myProducts.Add(new MyProduct(product));
                }

                List<MyProduct> products = MyProduct.GetMyProductByName("Nut");
                Assert.AreEqual(1, products.Count);
                foreach (Product product in products)
                    Assert.IsTrue(product.Name.Contains("Nut"));
            }
        }

        [TestMethod]
        public void GetProductsWithNRecentReviewsTest()
        {
            MyProductRepository.myProducts.Clear();

            using (ProductionDataContext db = new ProductionDataContext())
            {
                List<Product> productList = db.GetFirstNProducts(20);

                foreach (Product product in productList)
                {
                    MyProductRepository.myProducts.Add(new MyProduct(product));
                }

                List<MyProduct> products = MyProduct.GetProductsWithNRecentReviews(0);
                Assert.AreEqual(20, products.Count);
            }
        }

        [TestMethod]
        public void GetNRecentlyReviewedProducts()
        {
            MyProductRepository.myProducts.Clear();

            using (ProductionDataContext db = new ProductionDataContext())
            {
                List<Product> productList = db.GetFirstNProducts(500);

                foreach (Product product in productList)
                {
                    MyProductRepository.myProducts.Add(new MyProduct(product));
                }

                List<MyProduct> products = MyProduct.GetNRecentlyReviewedProducts(1);
                Assert.AreEqual(1, products.Count);
                Assert.AreEqual("Road-550-W Yellow, 40", products[0].Name);
            }
        }
    }
}
