using SegundaEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaEntrega.Database
{
    internal class GestorProductoVendido
    {
        private string connectionString;

        public GestorProductoVendido()
        {
            connectionString = "Server=.;Database=SistemaGestion;Trusted_Connection=True;";
        }
        public bool DeleteProductoVendido(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ProductoVendido WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                conn.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
        public bool CreateProductoVendido(ProductoVendido productoVendido)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ProductoVendido(Stock,IdProducto,IdVenta)" +
                    "VALUES(@Stock,@IdProducto,@IdVenta)";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Stock", productoVendido.Stock);
                command.Parameters.AddWithValue("@IdProducto", productoVendido.IdProducto);
                command.Parameters.AddWithValue("@IdVenta", productoVendido.IdVenta);
                conn.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public ProductoVendido GetProductoVendidoByID(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ProductoVendido WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int productoVendidoId = Convert.ToInt32(reader["Id"]);
                    int stock = Convert.ToInt32(reader["Stock"]);
                    int idProducto = Convert.ToInt32(reader["IdProducto"]);
                    int idVenta = Convert.ToInt32(reader["IdVenta"]);
                    ProductoVendido productoVendido = new ProductoVendido(productoVendidoId, stock, idProducto, idVenta);
                    return productoVendido;
                }
                throw new Exception("Id no encontrado");
            }
        }

        public bool UpdateProductoVendido(int id, ProductoVendido productoVendido)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE ProductoVendido SET Stock = @Stock, IdProducto = @IdProducto, IdVenta = @IdVenta WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Stock", productoVendido.Stock);
                command.Parameters.AddWithValue("@IdProducto", productoVendido.IdProducto);
                command.Parameters.AddWithValue("@IdVenta", productoVendido.IdVenta);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public List<ProductoVendido> ListaProductoVendido()
        {
            List<ProductoVendido> listaProductoVendido = new List<ProductoVendido>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ProductoVendido";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductoVendido productoVendido = new ProductoVendido();
                            productoVendido.Id = Convert.ToInt32(reader["Id"]);
                            productoVendido.Stock = Convert.ToInt32(reader["Stock"]);
                            productoVendido.IdProducto = Convert.ToInt32(reader["IdProducto"]);
                            productoVendido.IdVenta = Convert.ToInt32(reader["IdVenta"]);
                            listaProductoVendido.Add(productoVendido);
                        }
                    }
                }
                return listaProductoVendido;
            }
        }
    }
}
