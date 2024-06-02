using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaEntrega.Models
{
    internal class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; } // por el momento le pongo double porque puede haber productos que se stockeen por kilo... cuando sepa bien de que va el proyecto modifico si es necesario
        public int IdUsuario { get; set; }

        public Producto() { }

        public Producto(string descripcion, double costo, double precioVenta, int stock, int idUsuario)
        {
            this.Descripcion = descripcion;
            this.Costo = costo;
            this.PrecioVenta = precioVenta;
            this.Stock = stock;
            this.IdUsuario = idUsuario;
        }

        public Producto(int id, string descripcion, double costo, double precioVenta, int stock, int idUsuario)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Costo = costo;
            this.PrecioVenta = precioVenta;
            this.Stock = stock;
            this.IdUsuario = idUsuario;
        }
        public override string ToString()
        {
            return $"ID = {this.Id} - Descripcion = {this.Descripcion} - Costo = {this.Costo} - PrecioVenta = {this.PrecioVenta} - Stock = {this.Stock} - IdUsuario = {this.IdUsuario}";
        }
    }
}
