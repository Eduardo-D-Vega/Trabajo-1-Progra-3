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
        public int NumUnico { get; private set; }
        private DateTime Fecha { get; set; }
        public List<ListaItem> ListaItems { get; set; }
        public bool OrdenRecibida { get; set; }

        public OrdenDeCompra(int id, DateTime fecha)
        {
            NumUnico = id;
            Fecha = fecha;
            ListaItems = new List<ListaItem>();
        }

        public void AgregarProductos(List<Producto> productos)
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("\nLa lista de productos está vacía.\n");
                return;
            }

            bool continuar = true;
            while (continuar)
            {
                int opcion = 0;
                bool valido = false;

                // Seleccionar producto
                do
                {
                    try
                    {
                        Console.WriteLine("\nSeleccione un producto de la lista:");
                        for (int i = 0; i < productos.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {productos[i].Nombre} - {productos[i].Descripcion} - " +
                                              $"[Proveedor: {productos[i].ProveedorAsociado.Nombre}] - [Precio: {productos[i].PrecioUnidad}]");
                        }

                        Console.Write("Ingrese el número de la opción: ");
                        if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > productos.Count)
                            throw new Exception("Debe ingresar un número válido de la lista.");

                        valido = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        valido = false;
                    }
                } while (!valido);

                Producto ProductoSeleccionado = productos[opcion - 1];

                // Ingresar cantidad
                int cantidadProducto = 0;
                valido = false;
                do
                {
                    try
                    {
                        Console.Write("Ingrese la cantidad de productos que desea: ");
                        if (!int.TryParse(Console.ReadLine(), out cantidadProducto) || cantidadProducto < 1)
                            throw new Exception("La cantidad debe ser un número mayor a cero.");
                        valido = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        valido = false;
                    }
                } while (!valido);

                ListaItems.Add(new ListaItem(ProductoSeleccionado, cantidadProducto));
                Console.WriteLine("\nEl producto fue agregado a la orden de compra.");

                // Preguntar si desea seguir
                string respuesta = "";
                valido = false;
                do
                {
                    try
                    {
                        Console.Write("\n¿Desea agregar otro producto? (si/no): ");
                        respuesta = Console.ReadLine().Trim().ToLower();
                        if (respuesta != "si" && respuesta != "no")
                            throw new Exception("Debe responder únicamente con 'si' o 'no'.");
                        valido = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        valido = false;
                    }
                } while (!valido);

                continuar = (respuesta == "si");
            }
        }

        public decimal ValorTotalOrdenCompra()
        {
            decimal ValorTotal = 0;
            foreach (var productosItems in ListaItems)
                ValorTotal += productosItems.Producto.PrecioUnidad * productosItems.Cantidad;
            return ValorTotal;
        }

        public static void VisualizarOrdenesCompra(List<OrdenDeCompra> ordenes)
        {
            if (ordenes.Count == 0)
            {
                Console.WriteLine("No hay órdenes de compra registradas\n");
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



}



