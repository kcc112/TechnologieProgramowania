using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;
using Zadanie3.LinqToSql;

namespace Tests
{
    [TestClass]
    public class Stage3Test
    {
        #region Declarative - used from
        #region Get by name
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
        public void GetProductNamesByVendorNameTets()
        {
            List<string> products = Stage3.GetProductNamesByVendorName("Jeff's Sporting Goods");
            Assert.AreEqual(4, products.Count);
            Assert.AreEqual("Mountain Bike Socks, M", products[0]);
        }

        [TestMethod]
        public void GetProductVendorByProductNameTest()
        {
            string product = Stage3.GetProductVendorByProductName("Flat Washer 1");
            Assert.AreEqual("Continental Pro Cycles", product);
        }
        #endregion

        #region Count
        [TestMethod]
        public void GetProductsWithNRecentReviewsTest()
        {
            List<Product> products = Stage3.GetProductsWithNRecentReviews(2);
            Assert.AreEqual(1, products.Count);
            Assert.IsNotNull(products.Find(product => product.ProductID.Equals(937)));
        }

        [TestMethod]
        public void GetNRecentlyReviewedProductsTest()
        {
            List<Product> products = Stage3.GetNRecentlyReviewedProducts(1);
            Assert.AreEqual(1, products.Count);
            Assert.AreEqual("HL Mountain Pedal", products[0].Name);
        }

        [TestMethod]
        public void GetNProductsFromCategoryTest()
        {
            List<Product> products = Stage3.GetNProductsFromCategory("Bikes", 1);
            Assert.AreEqual(1, products.Count);
        }
        #endregion

        #region Sum
        [TestMethod]
        public void GetTotalStandardCostByCategoryTest()
        {
            ProductCategory accessories = new ProductCategory
            {
                Name = "Accessories"
            };

            Assert.AreEqual(383, Stage3.GetTotalStandardCostByCategory(accessories));
        }
        #endregion
        #endregion

        #region Imperative - used Extension Methods
        #region Get by name
        [TestMethod]
        public void GetProductsByNameExtendTest()
        {
            List<Product> products = Stage3.GetProductsByNameExtend("Nut");
            Assert.AreEqual(79, products.Count);
            foreach (Product product in products)
                Assert.IsTrue(product.Name.Contains("Nut"));
        }

        [TestMethod]
        public void GetProductsByVendorNameExtendTest()
        {
            List<Product> products = Stage3.GetProductsByVendorNameExtend("Jeff's Sporting Goods");
            Assert.AreEqual(4, products.Count);
        }

        [TestMethod]
        public void GetProductNamesByVendorExtendNameTest()
        {
            List<string> products = Stage3.GetProductNamesByVendorNameExtend("Jeff's Sporting Goods");
            Assert.AreEqual(4, products.Count);
            Assert.AreEqual("Mountain Bike Socks, M", products[0]);
        }

        [TestMethod]
        public void GetProductVendorByProductNameExtendTest()
        {
            string product = Stage3.GetProductVendorByProductNameExtend("Flat Washer 1");
            Assert.AreEqual("Continental Pro Cycles", product);
        }
        #endregion

        #region Count
        [TestMethod]
        public void GetProductsWithNRecentReviewsExtendTest()
        {
            List<Product> products = Stage3.GetProductsWithNRecentReviewsExtend(2);
            Assert.AreEqual(1, products.Count);
            Assert.IsNotNull(products.Find(product => product.ProductID.Equals(937)));
        }

        [TestMethod]
        public void GetNRecentlyReviewedProductsExtendTest()
        {
            List<Product> products = Stage3.GetNRecentlyReviewedProductsExtend(1);
            Assert.AreEqual(1, products.Count);
            Assert.AreEqual("HL Mountain Pedal", products[0].Name);
        }

        [TestMethod]
        public void GetNProductsFromCategoryExtendTest()
        {
            List<Product> products = Stage3.GetNProductsFromCategoryExtend("Bikes", 1);
            Assert.AreEqual(1, products.Count);
        }
        #endregion

        #region Sum
        [TestMethod]
        public void GetTotalStandardCostByCategoryExtendTest()
        {
            ProductCategory accessories = new ProductCategory
            {
                Name = "Accessories"
            };

            Assert.AreEqual(383, Stage3.GetTotalStandardCostByCategoryExtend(accessories));
        }
        #endregion
        #endregion
    }
}
