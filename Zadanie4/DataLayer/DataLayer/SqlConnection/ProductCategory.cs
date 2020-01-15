
namespace DataLayer.SqlConnection
{
    public partial class ProductCategory
    {
        public override string ToString()
        {
            return "Name: " +  Name + " " + "ID: " + ProductCategoryID;
        }

        public string Info
        {
            get => ToString();
        }
    }
}
