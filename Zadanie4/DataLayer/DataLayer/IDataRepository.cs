﻿using DataLayer.SqlConnection;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IDataRepository
    {
        List<ProductCategory> GetAllProductCategories();

        void AddProductCategory(ProductCategory productCategory);

        void UpdateProductCategory(string name, int id);

        void DeleteProductCategory(int id);
    }
}