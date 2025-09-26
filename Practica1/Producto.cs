using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    public class Producto : INombre
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnidad { get; set; }

        public Producto (string nombre, string descripcion, decimal precioUnidad) 
        {
            Nombre = nombre;
            Descripcion = descripcion;
            PrecioUnidad = precioUnidad;
        }
    }

}
