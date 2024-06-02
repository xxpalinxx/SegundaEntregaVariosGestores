using SegundaEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaEntrega.Database
{
    internal class GestorVenta
    {
        private string connectionString;

        public GestorVenta()
        {
            connectionString = "Server=.;Database=SistemaGestion;Trusted_Connection=True;";
        }
        public bool DeleteVenta(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Venta WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                conn.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool CreateVenta(Venta venta)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Venta(Comentarios, IdUsuario)" +
                    "VALUES(@Comentarios, @IdUsuario)";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Comentario", venta.Comentarios);
                command.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);
                conn.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public Venta GetVentaByID(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Venta WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int ventaId = Convert.ToInt32(reader["Id"]);
                    string comentarios = reader["Comentarios"].ToString();
                    int idUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    Venta venta = new Venta(ventaId, comentarios, idUsuario);
                    return venta;
                }
                throw new Exception("Id no encontrado");
            }
        }

        public bool UpdateVenta(int id, Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Venta SET Comentarios = @Comentarios, IdUsuario = @IdUsuario WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Comentarios", venta.Comentarios);
                command.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public List<Venta> ListaVenta()
        {
            List<Venta> listaVenta = new List<Venta>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Venta";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Venta venta = new Venta();
                            venta.Id = Convert.ToInt32(reader["Id"]);
                            venta.Comentarios = reader["Nombre"].ToString();
                            venta.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                            listaVenta.Add(venta);
                        }
                    }
                }
                return listaVenta;
            }
        }
    }
}
