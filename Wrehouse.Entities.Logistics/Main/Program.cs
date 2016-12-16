using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DAO.Logistics;
using Warehouse.Entities.Logistics;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            StringWriter sw = new StringWriter();
            Random Random = new Random(DateTime.Now.Millisecond);
           // int ProductID = ProductDAO.Insertar(new Product("producto 1", "desc del p1", (float)(Random.NextDouble() * 100d)));

           // sw.WriteLine("product id = {0}", ProductID);
            //sw.WriteLine("product id = {0}", 2);
            Console.WriteLine(ProductDAO.ObtenerProducto(21));

          //  Console.WriteLine(sw);
            Console.ReadLine();
        }
    }
}
