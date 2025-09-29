using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Practica1
{
    public class OrdenDeCompra
    {
        public int NumUnico { get; set; }
        private DateTime Fecha { get; set; }
        public Proveedor ProveedorSeleccionado { get; set; }
        public Proveedor Proveedor { get; set; }
        public List<ListaItem> ListaItems { get; set; }  //cada orden de compra tendra su propia lista de items
        public bool OrdenRecibida { get; set; } = false; 

        public OrdenDeCompra(int id, DateTime fecha)
        {
            NumUnico = id;
            Fecha = fecha;
            ListaItems = new List<ListaItem>();
        }

        public decimal ValorTotalOrdenCompra()
        {
            decimal ValorTotal = 0;
            foreach (var productosItems in ListaItems)
            {
                ValorTotal += productosItems.Producto.PrecioUnidad * productosItems.Cantidad;
            }
            return ValorTotal;
        }

        public static void VisualizarOrdenesCompra(List<OrdenDeCompra> ordenes)
        {
            if (ordenes.Count == 0)
            {
                Console.WriteLine("No hay ordenes de compra registradas\n");
                return;
            }

            Console.WriteLine("\nOrdenes de compra existentes");

            foreach (var ordencompra in ordenes)
            {
                Console.WriteLine($"Orden N-{ordencompra.NumUnico}");
                Console.WriteLine($"Fecha: {ordencompra.Fecha}");
                Console.WriteLine($"Productos:");

                decimal TotalOrdenCompra = 0;

                foreach (var item in ordencompra.ListaItems)
                {
                    decimal Subtotal = item.Producto.PrecioUnidad * item.Cantidad;

                    Console.WriteLine($"{item.Producto.Nombre} (Proveedor: {item.Producto.ProveedorAsociado.Nombre})");
                    Console.WriteLine($"Cantidad: {item.Cantidad}");
                    Console.WriteLine($"Subtotal: {Subtotal}");

                    TotalOrdenCompra += Subtotal;
                }

                Console.WriteLine($"Total de la orden: {ordencompra.ValorTotalOrdenCompra()}");
            }
        }
    }


}



