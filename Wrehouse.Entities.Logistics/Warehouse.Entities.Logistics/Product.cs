using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Entities.Logistics
{
    public class Product
    {
        public Product(string ProductName, string Description, float Price)
        {
            this.ProductName = ProductName;
            this.Description = Description;
            this.Price = Price;
        }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", ProductID, ProductName, Description, Price);
        }
    }
}
