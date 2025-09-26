using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    public class OrdenDeCompra
    {
        public int NumUnico { get; set; }
        public DateTime Fecha { get; set; }
        public Proveedor ProveedorSeleccionado { get; set; }


        public OrdenDeCompra(int id, DateTime fecha, Proveedor proveedor)
        {
            NumUnico = id;
            Fecha = fecha;
        }

        public void SeleccionarProveedor(List<Proveedor> proveedores)
        {
            Console.WriteLine("Seleccione un proveedor de la lista");
      
            for (int i = 0; i < proveedores.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {proveedores[i].Nombre}");
            }
            int opcion = int.Parse(Console.ReadLine());
            ProveedorSeleccionado = proveedores[opcion - 1];

            Console.WriteLine($"Proveedor seleccionado: {ProveedorSeleccionado.Nombre}\n");
        
        }
        
    }

}
