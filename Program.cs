

using SegundaEntrega.Database;
using SegundaEntrega.Models;

namespace SegundaEntrega
{
    public class Program
    {
        static void Main(string[] args)
        {
            GestorProducto gestorProducto = new GestorProducto();
            GestorProductoVendido gestorProductoVendido = new GestorProductoVendido();
            GestorUsuario gestorUsuario = new GestorUsuario();
            GestorVenta gestorVenta = new GestorVenta();

            try
            {
                Producto productoNuevo = new Producto("Cartera",100.00,350.00,20,5);
                if (gestorProducto.CreateProduct(productoNuevo))
                {
                    Console.WriteLine("Producto Creado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Usuario nuevoUsuario = new Usuario("Estefania", "Dominico", "Stefy", "asdg3asd", "stefy@gmail.com");
                if (gestorUsuario.CreateUser(nuevoUsuario))
                {
                    Console.WriteLine("Usuario Creado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
