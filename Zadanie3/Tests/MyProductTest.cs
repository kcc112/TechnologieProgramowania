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
        public void TestMethod1()
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
    }
}
