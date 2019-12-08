using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;
using Zadanie3.LinqToSql;

namespace Tests
{
    [TestClass]
    public class Stage3Test
    {

        [TestMethod]
        public void GetProductsByNameTest()
        {
            List<Product> products = Stage3.GetProductsByName("Nut");
            Assert.AreEqual(79, products.Count);
            foreach (Product product in products)
                Assert.IsTrue(product.Name.Contains("Nut"));
        }

        [TestMethod]
        public void GetProductsByVendorNameTest()
        {
            List<Product> products = Stage3.GetProductsByVendorName("Jeff's Sporting Goods");
            Assert.AreEqual(4, products.Count);
        }

        [TestMethod]
        public void GetProductNamesByVendorName()
        {
            List<string> products = Stage3.GetProductNamesByVendorName("Jeff's Sporting Goods");
            Assert.AreEqual(4, products.Count);
            Assert.AreEqual("Mountain Bike Socks, M", products[0]);
        }

        [TestMethod]
        public void GetProductVendorByProductName()
        {
            string product = Stage3.GetProductVendorByProductName("Flat Washer 1");
            Assert.AreEqual("Continental Pro Cycles", product);
        }

        [TestMethod]
        public void GetProductsWithNRecentReviews()
        {
            List<Product> products = Stage3.GetProductsWithNRecentReviews(2);
            Assert.AreEqual(1, products.Count);
            Assert.IsNotNull(products.Find(product => product.ProductID.Equals(937)));
        }

        [TestMethod]
        public void GetNRecentlyReviewedProducts()
        {
            List<Product> products = Stage3.GetNRecentlyReviewedProducts(1);
            Assert.AreEqual(1, products.Count);
            Assert.AreEqual("HL Mountain Pedal", products[0].Name);
        }

        [TestMethod]
        public void GetNProductsFromCategory()
        {
            List<Product> products = Stage3.GetNProductsFromCategory("Bikes", 1);
            Assert.AreEqual(1, products.Count);
        }

        [TestMethod]
        public void GetTotalStandardCostByCategory()
        {
            ProductCategory accessories = new ProductCategory
            {
                Name = "Accessories"
            };

            Assert.AreEqual(383, Stage3.GetTotalStandardCostByCategory(accessories));
        }
    }
}
