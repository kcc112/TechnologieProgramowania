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
                DataRepository dataRepository = new DataRepository();
                IEnumerable<ProductCategory> productCategories = dataRepository.GetAllProductCategories();
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

                DataRepository dataRepository = new DataRepository();
                dataRepository.AddProductCategory(productCategory);
                IEnumerable<ProductCategory> productCategories = dataRepository.GetAllProductCategories();
                Assert.AreEqual(5, productCategories.ToList().Count);
            }

            [TestMethod]
            public void DeleteProductCategoryTest()
            {
                DataRepository dataRepository = new DataRepository();
                dataRepository.DeleteProductCategory(5);
                IEnumerable<ProductCategory> productCategories = dataRepository.GetAllProductCategories();
                Assert.AreEqual(4, productCategories.ToList().Count);
            }


            [TestMethod]
            public void UpdateUpdateProductCategoryTest()
            {
                DataRepository dataRepository = new DataRepository();
                dataRepository.UpdateProductCategory("Mirek", 1);
                IEnumerable<ProductCategory> scrapReasons = dataRepository.GetAllProductCategories();
                Assert.AreEqual("Mirek", scrapReasons.ToList()[0].Name);
            }

            [TestMethod]
            public void GetProductCategoryByNameTest()
            {
                DataRepository dataRepository = new DataRepository();
                dataRepository.UpdateProductCategory("Mirek", 1);
                ProductCategory scrapReasons = dataRepository.GetProductCategoryByName("Mirek");
                Assert.AreEqual("Mirek", scrapReasons.Name);
            }

            [TestMethod]
            public void GetProductCategoryByIdTest()
            {
                DataRepository dataRepository = new DataRepository();
                dataRepository.UpdateProductCategory("Mirek", 1);
                ProductCategory scrapReasons = dataRepository.GetProductCategoryById(1);
                Assert.AreEqual("Mirek", scrapReasons.Name);
            }
        }
    }
}
