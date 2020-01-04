using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
