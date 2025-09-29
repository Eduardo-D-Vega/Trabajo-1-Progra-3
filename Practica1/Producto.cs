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
        public int almacen { get; set; } //cantidad de productos disponibles en el inventario

        public Producto(string nombre, string descripcion, decimal precio)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            PrecioUnidad = precio;
            almacen = 0;
        }

        public void RegistrarProducto(List<Producto> productos)
        {
            bool valido = false;

            do
            {
                try
                {
                    Console.WriteLine("Ingrese el nombre del producto:");
                    Nombre = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(Nombre) || !Nombre.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                    {
                        throw new Exception("El nombre solo puede contener letras y espacios.");
                    }

                    valido = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    valido = false;
                }
            } while (!valido);

            do
            {
                try
                {
                    Console.WriteLine("Ingrese la descripción del producto:");
                    Descripcion = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(Descripcion))
                    {
                        throw new Exception("La descripción no puede estar vacía.");
                    }

                    valido = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    valido = false;
                }
            } while (!valido);

            decimal precio = 0;
            do
            {
                try
                {
                    Console.WriteLine("Ingrese el precio por unidad:");
                    if (!decimal.TryParse(Console.ReadLine(), out precio) || precio <= 0)
                    {
                        throw new Exception("El precio debe ser un número decimal válido mayor a 0.");
                    }

                    PrecioUnidad = precio;
                    valido = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    valido = false;
                }
            } while (!valido);

            productos.Add(this);
            Console.WriteLine("\n El producto fue registrado correctamente\n");
        }

        public void AgregarProductos(List<Producto> productos, List<ListaItem> listaItems)
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("\n La lista de productos está vacía, debe registrar productos antes de continuar\n");
                return; // vuelve al menú
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
                            Console.WriteLine($"{i + 1}. {productos[i].Nombre} - {productos[i].Descripcion} - [Precio: {productos[i].PrecioUnidad}]");
                        }

                        Console.Write("Ingrese el número de la opción: ");
                        if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > productos.Count)
                        {
                            throw new Exception("Debe ingresar un número válido de la lista.");
                        }

                        valido = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        valido = false;
                    }
                } while (!valido);

                Producto ProductoSeleccionado = productos[opcion - 1];

                int cantidadProducto = 0;
                valido = false;
                do
                {
                    try
                    {
                        Console.Write("Ingrese la cantidad de productos que desea: ");
                        if (!int.TryParse(Console.ReadLine(), out cantidadProducto) || cantidadProducto < 1)
                        {
                            throw new Exception("La cantidad debe ser un número mayor a cero.");
                        }

                        valido = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        valido = false;
                    }
                } while (!valido);

                //se suman las cantidades si un producto ya existe en la orden de compra
                var itemregistrado = listaItems.FirstOrDefault(i => i.Producto == ProductoSeleccionado);
                if (itemregistrado != null)
                {
                    itemregistrado.Cantidad += cantidadProducto;
                    Console.WriteLine($"\nLa cantidad del producto se actualizo a {itemregistrado.Cantidad}");
                }

                else
                {
                    listaItems.Add(new ListaItem(ProductoSeleccionado, cantidadProducto));
                    Console.WriteLine("\n El producto fue agregado a la orden de compra.");
                }

                //Pregunta si desea seguir
                string respuesta = "";
                valido = false;
                do
                {
                    try
                    {
                        Console.Write("\n¿Desea agregar otro producto? (si/no): ");
                        respuesta = Console.ReadLine().Trim().ToLower();

                        if (respuesta != "si" && respuesta != "no")
                        {
                            throw new Exception("Debe responder únicamente con 'si' o 'no'.");
                        }

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
    }
}