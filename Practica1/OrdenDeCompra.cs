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
        private int NumUnico { get; set; }
        private DateTime Fecha { get; set; }
        public Proveedor ProveedorSeleccionado { get; set; }
        public List<ListaItem> ListaItems { get; set; }  //cada orden de compra tiene su propia lista de items
        public bool OrdenRecibida { get; set; } 

        public OrdenDeCompra(int id, DateTime fecha)
        {
            NumUnico = id;
            Fecha = fecha;
            ProveedorSeleccionado = null;
            ListaItems = new List<ListaItem>();
        }

        public void SeleccionarProveedor(List<Proveedor> proveedores)
        {
            if (proveedores.Count == 0)
            {
                Console.WriteLine("\nNo hay proveedores registrados\n");
                return; //Tiene que volver a pedir que seleccione un proveedor
            }

            Console.WriteLine("\nSeleccione un proveedor de la lista");

            for (int i = 0; i < proveedores.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {proveedores[i].Nombre}");
            }

            int opcion = int.Parse(Console.ReadLine());

            ProveedorSeleccionado = proveedores[opcion - 1];

            Console.WriteLine($"El proveedor seleccionado es: {ProveedorSeleccionado.Nombre}\n");
        }
        
        public void AgregarProductos(List<Producto> productos)
        {
            while (productos.Count == 0)
            {
                Console.WriteLine("La lista está vacía, debe agregar productos antes de continuar\n");
                return; //vuelve al menu
            }

            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("Seleccione un producto de la lista");

                for (int i = 0; i < productos.Count; i++)
                {
                    Console.WriteLine($"{i + 1} {productos[i].Nombre} - {productos[i].Descripcion} - [Precio: {productos[i].PrecioUnidad}]");
                }

                int opcion = int.Parse(Console.ReadLine());
                Producto ProductoSeleccionado = productos[opcion - 1];

                Console.WriteLine("Ingrese la cantidad de productos que desea: ");
                int cantidadProducto = int.Parse(Console.ReadLine());

                if (cantidadProducto < 1)
                {
                    Console.WriteLine("La cantidad ingresada debe ser mayor a cero\n");
                    continue;
                }

                ListaItems.Add(new ListaItem(ProductoSeleccionado, cantidadProducto));
                Console.WriteLine("\nEl producto fue agregado a la orden de compra");

                Console.Write("¿Digite 'si o no' si desea agregar otro producto? ");
                continuar = Console.ReadLine().ToLower() == "si";
            }
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
                Console.WriteLine($"Proveedor: {ordencompra.ProveedorSeleccionado.Nombre}");
                Console.WriteLine($"Productos:");

                decimal TotalOrdenCompra = 0;

                foreach (var item in ordencompra.ListaItems)
                { 
                    decimal Subtotal = item.Producto.PrecioUnidad * item.Cantidad;

                    Console.WriteLine($"{item.Producto.Nombre}\nCantidad: {item.Cantidad}");
                    Console.WriteLine($"Subtotal: {Subtotal}");

                    TotalOrdenCompra += Subtotal;
                }

                Console.WriteLine($"Total de la orden: {ordencompra.ValorTotalOrdenCompra()}");
            }
        }
    }

}



