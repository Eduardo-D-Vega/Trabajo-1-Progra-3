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

        public OrdenDeCompra(int id, DateTime fecha)
        {
            NumUnico = id;
            Fecha = fecha;
            ProveedorSeleccionado = null;
        }

        public void SeleccionarProveedor(List<Proveedor> proveedores)
        {
            if (proveedores.Count == 0)
            {
                Console.WriteLine("No hay proveedores registrados\n");
                return; //Tiene que volver a pedir que seleccione un proveedor
            }

            Console.WriteLine("Seleccione un proveedor de la lista");

            for (int i = 0; i < proveedores.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {proveedores[i].Nombre}");
            }

            int opcion = int.Parse(Console.ReadLine());

                ProveedorSeleccionado = proveedores[opcion - 1];

                Console.WriteLine($"Proveedor seleccionado: {ProveedorSeleccionado.Nombre}\n");
        }
        
        public void AgregarProductos(List<Producto> productos, List<ListaItem> listaItems)
        {
            while (productos.Count == 0)
            {
                Console.WriteLine("La lista está vacía, debe agregar productos antes\n");
                return; //vuelve al menu
            }

            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("Seleccione un producto de la lista\n");

                for (int i = 0; i < productos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {productos[i].Nombre} → {productos[i].Descripcion}  [Precio: {productos[i].PrecioUnidad:c}]");
                }

                int opcion = int.Parse(Console.ReadLine());
                Producto ProductoSeleccionado = productos[opcion - 1];

                Console.WriteLine($"\nIngrese la cantidad de productos que desea: ");
                int cantidadProducto = int.Parse(Console.ReadLine());

                if (cantidadProducto < 1)
                {
                    Console.WriteLine("La cantidad ingresada debe ser mayor a cero\n");
                    continue;
                }

                listaItems.Add(new ListaItem(ProductoSeleccionado, cantidadProducto));
                Console.WriteLine("El producto fue agregado a la orden de compra");

                Console.Write("¿Digite 'si o no' si desea agregar otro producto? ");
                continuar = Console.ReadLine().ToLower() == "si";
            }
        }

        public decimal ValorTotalOrdenCompra(List<ListaItem> listaCantidadProductos)
        {
            decimal ValorTotal = 0;

            foreach (var items in listaCantidadProductos)
            {
                ValorTotal += items.Producto.PrecioUnidad * items.Cantidad;
            }

            Console.WriteLine($"\nEl valor total de la orden de compra es de: {ValorTotal}\n");
            return ValorTotal;   
        }

    }
}


