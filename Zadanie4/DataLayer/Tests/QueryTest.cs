using System.Collections.Generic;
using DataLayer;
using DataLayer.SqlConnection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class QueryTest
    {
        [TestMethod]
        public void GetProductsByNameTest()
        {
            List<Product> products = Query.GetProductsByName("Nut");
            Assert.AreEqual(79, products.Count);
            foreach (Product product in products)
                Assert.IsTrue(product.Name.Contains("Nut"));
        }

        [TestMethod]
        public void GetProductsByVendorNameTest()
        {
            List<Product> products = Query.GetProductsByVendorName("Jeff's Sporting Goods");
            Assert.AreEqual(4, products.Count);
        }

        [TestMethod]
        public void GetProductNamesByVendorNameTets()
        {
            List<string> products = Query.GetProductNamesByVendorName("Jeff's Sporting Goods");
            Assert.AreEqual(4, products.Count);
            Assert.AreEqual("Mountain Bike Socks, M", products[0]);
        }

        [TestMethod]
        public void GetProductVendorByProductNameTest()
        {
            string product = Query.GetProductVendorByProductName("Flat Washer 1");
            Assert.AreEqual("Continental Pro Cycles", product);
        }

        [TestMethod]
        public void GetProductsWithNRecentReviewsTest()
        {
            List<Product> products = Query.GetProductsWithNRecentReviews(2);
            Assert.AreEqual(1, products.Count);
            Assert.IsNotNull(products.Find(product => product.ProductID.Equals(937)));
        }

        [TestMethod]
        public void GetNRecentlyReviewedProductsTest()
        {
            List<Product> products = Query.GetNRecentlyReviewedProducts(1);
            Assert.AreEqual(1, products.Count);
            Assert.AreEqual("HL Mountain Pedal", products[0].Name);
        }

        [TestMethod]
        public void GetNProductsFromCategoryTest()
        {
            List<Product> products = Query.GetNProductsFromCategory("Bikes", 1);
            Assert.AreEqual(1, products.Count);
        }

        [TestMethod]
        public void GetTotalStandardCostByCategoryTest()
        {
            ProductCategory accessories = new ProductCategory
            {
                Name = "Accessories"
            };

            Assert.AreEqual(383, Query.GetTotalStandardCostByCategory(accessories));
        }
    }
}
