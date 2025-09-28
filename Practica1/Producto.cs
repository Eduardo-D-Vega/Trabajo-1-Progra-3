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
            try
            {
                Console.WriteLine("Ingrese el nombre del producto:");
                Nombre = Console.ReadLine();

                Console.WriteLine("Ingrese la descripción del producto:");
                Descripcion = (Console.ReadLine());
                //validacion de que el precio sea un numero
                decimal precio;
                while (true)
                {

                    Console.WriteLine("Ingrese el precio por unidad:");
                    string entrada = Console.ReadLine();
                    if (decimal.TryParse(entrada, out precio))
                    {
                        PrecioUnidad = precio;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error: El precio debe ser un número decimal válido. Inténtelo de nuevo.");

                    }
                }

                productos.Add(this); //se agrega la instancia a la lista principal

                Console.WriteLine("\nEl producto fue registrado correctamente\n");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: El precio debe ser un número decimal válido.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar el produto: {ex.Message}\n");
            }
        }
    }
}