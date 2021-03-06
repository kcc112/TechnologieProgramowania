﻿using DataLayer.SqlConnection;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer
{
    public class DataRepository : IDataRepository
    {

        private ProductionDataContext db = new ProductionDataContext();

        public IEnumerable<ProductCategory> GetAllProductCategories()
        {
            IQueryable<ProductCategory> output = from productCategory in db.ProductCategories
                                                 select productCategory;
            return output;
        }

        public ProductCategory GetProductCategoryByName(string name)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                return db.ProductCategories.SingleOrDefault(productCategory => productCategory.Name == name);
            }
        }

        public void AddProductCategory(ProductCategory productCategory)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                db.ProductCategories.InsertOnSubmit(productCategory);
                db.SubmitChanges();
            }
        }

        public  void UpdateProductCategory(string name, int id)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                ProductCategory output = db.ProductCategories.SingleOrDefault(productCategory => productCategory.ProductCategoryID == id);

                output.Name = name;
                db.SubmitChanges();
            }
        }

        public void DeleteProductCategory(int id)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                ProductCategory output = db.ProductCategories.SingleOrDefault(productCategory => productCategory.ProductCategoryID == id);
                if (output != null)
                {
                    db.ProductCategories.DeleteOnSubmit(output);
                    db.SubmitChanges();
                }
            }
        }

        public ProductCategory GetProductCategoryById(int id)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                ProductCategory output = db.ProductCategories.SingleOrDefault(productCategory => productCategory.ProductCategoryID == id);
                return output;
            }
        }
    }
}
