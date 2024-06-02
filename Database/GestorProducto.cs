using SegundaEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaEntrega.Database
{
    internal class GestorProducto
    {
        private string connectionString;

        public GestorProducto()
        {
            connectionString = "Server=.;Database=SistemaGestion;Trusted_Connection=True;";
        }
        public bool DeleteProduct(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Producto WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                conn.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
        public bool CreateProduct(Producto producto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Producto(Descripciones,Costo,PrecioVenta,Stock,IdUsuario)" +
                    "VALUES(@Descripciones,@Costo,@PrecioVenta,@Stock,@IdUsuario)";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Descripciones", producto.Descripcion);
                command.Parameters.AddWithValue("@Costo", producto.Costo);
                command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                command.Parameters.AddWithValue("@Stock", producto.Stock);
                command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);
                conn.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
        public Producto GetProductByID(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Producto WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int productId = Convert.ToInt32(reader["Id"]);
                    string descripcion = reader["Descripciones"].ToString();
                    double costo = Convert.ToDouble(reader["Costo"]);
                    double precioVenta = Convert.ToDouble(reader["PrecioVenta"]);
                    int stock = Convert.ToInt32(reader["Stock"]);
                    int idUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    Producto producto = new Producto(productId, descripcion, costo, precioVenta, stock, idUsuario);
                    return producto;
                }
                throw new Exception("Id no encontrado");
            }
        }
        public bool UpdateProduct(int id, Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Usuario SET Descripciones = @Descripciones, Costo = @Costo, PrecioVenta = @PrecioVenta, Stock = @Stock, IdUsuario = @IdUsuario WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Descripciones", producto.Descripcion);
                command.Parameters.AddWithValue("@Costo", producto.Costo);
                command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                command.Parameters.AddWithValue("@Stock", producto.Stock);
                command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
        public List<Producto> ListaProductos()
        {
            List<Producto> listaProductos = new List<Producto>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Producto";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Producto producto = new Producto();
                            producto.Id = Convert.ToInt32(reader["Id"]);
                            producto.Descripcion = reader["Descripciones"].ToString();
                            producto.Costo = Convert.ToDouble(reader["Costo"]);
                            producto.PrecioVenta = Convert.ToDouble(reader["PrecioVenta"]);
                            producto.Stock = Convert.ToInt32(reader["Stock"]);
                            producto.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                            listaProductos.Add(producto);
                        }
                    }
                }
                return listaProductos;
            }
        }

    }
}
