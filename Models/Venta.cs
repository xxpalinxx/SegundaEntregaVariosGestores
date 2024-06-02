using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaEntrega.Models
{
    internal class Venta
    {
        public int Id { get; set; }
        public string Comentarios { get; set; }
        public int IdUsuario { get; set; }

        public Venta() { }
        public Venta(string comentarios, int idUsuario)
        {
            this.Comentarios = comentarios;
            this.IdUsuario = idUsuario;
        }

        public Venta(int id, string comentarios, int idUsuario)
        {
            this.Id = id;
            this.Comentarios = comentarios;
            this.IdUsuario = idUsuario;
        }

        public override string ToString()
        {
            return $"ID = {this.Id} - Comentarios = {this.Comentarios} -  IdUsuario = {this.IdUsuario}";
        }
    }
}
