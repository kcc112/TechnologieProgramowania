using DataLayer.SqlConnection;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IDataRepository
    {
        IEnumerable<ProductCategory> GetAllProductCategories();
        void AddProductCategory(ProductCategory productCategory);
        void UpdateProductCategory(string name, int id);
        void DeleteProductCategory(int id);
        ProductCategory GetProductCategoryById(int id);
    }
}
