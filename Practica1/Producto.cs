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
        public int almacen { get; set; }
        public Proveedor ProveedorAsociado { get; set; }  // 👈 Nuevo campo

        public Producto(string nombre, string descripcion, decimal precio)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            PrecioUnidad = precio;
            almacen = 0;
        }

        public void RegistrarProducto(List<Producto> productos, List<Proveedor> proveedores)
        {
            if (proveedores.Count == 0)
            {
                Console.WriteLine("\nDebe registrar al menos un proveedor antes de registrar un producto.\n");
                return;
            }

            bool valido = false;
            int opcion = 0;

            // === Selección de proveedor ===
            do
            {
                try
                {
                    Console.WriteLine("\nSeleccione el proveedor para este producto:");
                    for (int i = 0; i < proveedores.Count; i++)
                        Console.WriteLine($"{i + 1}. {proveedores[i].Nombre}");

                    Console.Write("Ingrese el número de la opción: ");
                    if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > proveedores.Count)
                        throw new Exception("Debe ingresar un número válido de la lista.");

                    ProveedorAsociado = proveedores[opcion - 1]; // 👈 asociación
                    valido = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    valido = false;
                }
            } while (!valido);

            // === Nombre ===
            do
            {
                try
                {
                    Console.WriteLine("Ingrese el nombre del producto:");
                    Nombre = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(Nombre)) throw new Exception("El nombre no puede estar vacío.");
                    valido = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    valido = false;
                }
            } while (!valido);

            // === Descripción ===
            do
            {
                try
                {
                    Console.WriteLine("Ingrese la descripción del producto:");
                    Descripcion = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(Descripcion)) throw new Exception("La descripción no puede estar vacía.");
                    valido = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    valido = false;
                }
            } while (!valido);

            // === Precio ===
            decimal precio = 0;
            do
            {
                try
                {
                    Console.WriteLine("Ingrese el precio por unidad:");
                    if (!decimal.TryParse(Console.ReadLine(), out precio) || precio <= 0)
                        throw new Exception("El precio debe ser un número válido mayor a 0.");
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
            Console.WriteLine($"\nProducto registrado correctamente con el proveedor {ProveedorAsociado.Nombre}\n");
        }
    }


}
