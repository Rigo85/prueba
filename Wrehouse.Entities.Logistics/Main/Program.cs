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

            //Enumerable.Range(1, 20).AsParallel().ForAll(i => {
            //    int ProductID = ProductDAO.Insertar(new Product(string.Format("product {0}", i), string.Format("desc del p{0}",0), (float)(Random.NextDouble() * 100d)));
            //});
        

            // int ProductID = ProductDAO.Insertar(new Product("producto 1", "desc del p1", (float)(Random.NextDouble() * 100d)));

            // sw.WriteLine("product id = {0}", ProductID);
            //sw.WriteLine("product id = {0}", 2);
            //var product = ProductDAO.ObtenerProducto(21);
            //product.Price = 54.344f;
            //product.Description = "nueva desc";

            //ProductDAO.Actualizar(product);

            //Console.WriteLine(ProductDAO.ObtenerProducto(21));

            //  Console.WriteLine(sw);

            //Console.WriteLine(ProductDAO.Eliminar(1));

            var list = ProductDAO.Listar(5, 2);
            ProductDAO.Listar(5, 2).ForEach(Console.WriteLine);

            Console.ReadLine();
        }
    }
}
