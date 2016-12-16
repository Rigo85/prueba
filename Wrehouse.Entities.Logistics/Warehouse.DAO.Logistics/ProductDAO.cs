using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Warehouse.Entities.Logistics;

namespace Warehouse.DAO.Logistics
{
    public class ProductDAO
    {
        //ConfigurationManager.ConnectionStrings["warehouse_conn"].ToString();
        public static string ConnectionString = "Server=AYS_LAP_002;Database=warehouse;Trusted_Connection=True;";

        public static int Insertar(Product product)
        {
            int ProductID = 0;

            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand("dbo.InsertarProducto", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("ProductName", product.ProductName);
                            cmd.Parameters.AddWithValue("Description", product.Description);
                            cmd.Parameters.AddWithValue("Price", product.Price);

                            ProductID = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }

                scope.Complete();
            }

            return ProductID;
        }

        public static bool Actualizar(Product product)
        {
            bool result = false;

            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("dbo.ActualizarProducto", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("ProductID", product.ProductID);
                            cmd.Parameters.AddWithValue("ProductName", product.ProductName);
                            cmd.Parameters.AddWithValue("Description", product.Description);
                            cmd.Parameters.AddWithValue("Price", product.Price);

                            result = cmd.ExecuteNonQuery() > 0 ? true : false;
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }

                scope.Complete();
            }

            return result;
        }

        public static bool Eliminar(int ProductID)
        {
            return true;
        }

        public static List<Product> Listar(int maxElements, int offset)
        {
            return new List<Product>();
        }

        public static List<Product> Listar()
        {
            return Listar(-1, -1);
        }

        public static Product ObtenerProducto(int ProductID)
        {
            Product Product = null;

            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("dbo.ObtenerProducto", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("ProductID", ProductID);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    Product = new Product(reader["ProductName"].ToString(), reader["ProductDesc"].ToString(), float.Parse(reader["Price"].ToString()));
                                    Product.ProductID = Convert.ToInt32(reader["ProductoID"]);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }

                scope.Complete();
            }

            return Product;
        }
    }
}
