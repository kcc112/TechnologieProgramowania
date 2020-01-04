using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.SqlConnection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer;

namespace Tests
{
    [TestClass]
    public class Repository
    {
        [TestClass]
        public class DataRepositoryTest
        {
            [TestMethod]
            public void GetAllProductCategoryTest()
            {
                IEnumerable<ProductCategory> productCategories = DataRepository.GetAllProductCategories();
                Assert.AreEqual(4, productCategories.ToList().Count);
            }

            [TestMethod]
            public void AddProductCategoryTest()
            {
                ProductCategory productCategory = new ProductCategory
                {
                    Name = "Kamil",
                    ModifiedDate = DateTime.Today
                };

                DataRepository.AddProductCategory(productCategory);
                IEnumerable<ProductCategory> productCategories = DataRepository.GetAllProductCategories();
                Assert.AreEqual(5, productCategories.ToList().Count);
            }

            [TestMethod]
            public void DeleteProductCategoryTest()
            {
                DataRepository.DeleteProductCategory(5);
                IEnumerable<ProductCategory> productCategories = DataRepository.GetAllProductCategories();
                Assert.AreEqual(4, productCategories.ToList().Count);
            }


            [TestMethod]
            public void UpdateUpdateProductCategory()
            {
                DataRepository.UpdateProductCategory("Mirek", 1);
                IEnumerable<ProductCategory> scrapReasons = DataRepository.GetAllProductCategories();
                Assert.AreEqual("Mirek", scrapReasons.ToList()[0].Name);
            }
        }
    }
}
