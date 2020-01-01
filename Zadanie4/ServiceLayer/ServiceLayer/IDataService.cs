using DataLayer.SqlConnection;
using System.Collections.Generic;

namespace ServiceLayer
{
    interface IDataService
    {
        List<ProductCategory> GetAllProductCategories();

        void AddProductCategory(string name);

        void UpdateProductCategory(string name, int id);

        void DeleteProductCategory(int id);
    }
}
