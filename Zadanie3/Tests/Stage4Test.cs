using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;
using Zadanie3.LinqToSql;

namespace Tests
{
    [TestClass]
    public class Stage4Test
    {
        #region Declarative - used from
        [TestMethod]
        public void GetProductsWithoutCategoryDeclarative()
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                List<Product> productList = db.GetFirstNProducts(20);
                List<Product> productListWithoutCategory = productList.GetProductsWithoutCategoryDeclarative();

                foreach (Product product in productListWithoutCategory)
                    Assert.IsNull(product.ProductSubcategory);
            }
        }

        [TestMethod]
        public void SplitToPagesDeclarative()
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                List<Product> productList = db.GetFirstNProducts(20);
                List<Product> productPage = productList.SplitToPagesDeclarative(1, 20);

                Assert.AreEqual(1, productPage.Count);
                Assert.AreEqual(productList[19].ProductID, productPage[0].ProductID);
            }
        }

        [TestMethod]
        public void ChangeToStringDeclarative()
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                List<ProductVendor> vendorList = db.GetFirstNProductVendor(20);
                List<Product> productList = db.GetFirstNProducts(20);
                string result = productList.ChangeToStringDeclarative(vendorList);
                string firstPair = result.Substring(0, result.IndexOf('\n') - 1);
                Assert.AreEqual("Adjustable Race-Litware, Inc.", firstPair);
            }
        }
        #endregion

        #region Imperative - used Extension Methods
        [TestMethod]
        public void GetProductsWithoutCategoryImperative()
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                List<Product> productList = db.GetFirstNProducts(20);
                List<Product> productListWithoutCategory = productList.GetProductsWithoutCategoryImperativ();

                foreach (Product product in productListWithoutCategory)
                    Assert.IsNull(product.ProductSubcategory);
            }
        }

        [TestMethod]
        public void SplitToPagesImperativ()
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                List<Product> productList = db.GetFirstNProducts(20);
                List<Product> productPage = productList.SplitToPagesImperativ(1, 20);

                Assert.AreEqual(1, productPage.Count);
                Assert.AreEqual(productList[19].ProductID, productPage[0].ProductID);
            }
        }

        [TestMethod]
        public void ChangeToStringImperativ()
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                List<ProductVendor> vendorList = db.GetFirstNProductVendor(20);
                List<Product> productList = db.GetFirstNProducts(20);
                string result = productList.ChangeToStringImperativ(vendorList);
                string firstPair = result.Substring(0, result.IndexOf('\n') - 1);
                Assert.AreEqual("Adjustable Race-Litware, Inc.", firstPair);
            }
        }
        #endregion
    }
}
