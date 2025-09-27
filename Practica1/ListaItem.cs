using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    public class ListaItem
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }

        public ListaItem(Producto producto, int cantidad)
        {
            Producto = producto;
            Cantidad = cantidad;
        }
    }
}
