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

    }
}