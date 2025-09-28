using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    public class Inventario
    {
        public List<Producto> productos { get; set; }  

        public Inventario()
        {
            productos = new List<Producto>();
        }

        public void AgregarProducto(Producto producto)
        {
            try
            {
                if (producto == null)
                {
                    Console.WriteLine("Error. El producto es nulo");
                    return;
                }

                productos.Add(producto);
                Console.WriteLine($"El producto {producto.Nombre} fue agregado al inventario");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hubo un error al agregar producto al inventario: {ex.Message}");
            }
        }

        public void MostrarInventario()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("El inventario esta vacío, no hay productos registrados");
                return;
            }

            Console.WriteLine("\nINVENTARIO");

            foreach (var stock in productos)
            {
                Console.WriteLine($"Producto: {stock.Nombre} - Stock: {stock.almacen}");
            }
        }

        public void ActualizarInventario(OrdenDeCompra orden)
        {
            try
            {
                if (orden == null)
                {
                    Console.WriteLine("Error. La orden de compra es nula");
                    return;
                }

                if (orden.ListaItems.Count == 0 || orden.ListaItems == null)
                {
                    Console.WriteLine("La orden de compra no tiene products");
                    return;
                }

                foreach (var item in orden.ListaItems)
                {
                    if (item.Producto == null)
                    {
                        Console.WriteLine("Error. Uno de los productos no es válido");
                        continue;
                    }

                    if (item.Cantidad < 1)
                    {
                        Console.WriteLine("La cantidad es inválida");
                        continue;
                    }

                    item.Producto.almacen += item.Cantidad;//se actualiza el inventario  
                }
                Console.WriteLine("El inventario ha sido actualizado");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrio un error al actualizar el inventario: {ex.Message}");
            }

        }
        public static void ActualizarOrdenesInventario(Inventario inventario, List<OrdenDeCompra> ordenes)
        {
            try
            {
                if (ordenes.Count == 0)
                {
                    Console.WriteLine("No hay ordenes de compras");
                    return;
                }

                //selecciona la ultima orden que fue creada
                OrdenDeCompra actualizarOrden = ordenes[ordenes.Count - 1];
                inventario.ActualizarInventario(actualizarOrden);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hubo un error al actualizar el inventario. Error: {ex.Message}");
            }
        }

    }
}

