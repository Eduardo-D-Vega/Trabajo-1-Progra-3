using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    public class Proveedor : INombre
    {
        public string Nombre { get; set; }
        private int Id { get; set; }
        private int Contacto { get; set; }
        public Proveedor ProveedorSeleccionado { get; set; }

        public Proveedor(string nombre, int id, int contacto)
        {
            Nombre = nombre;
            Id = id;    
            Contacto = contacto;
        }
        public static void RegistrarProveedor(List<Proveedor> proveedores)
        {
            string nombre = "";
            int id = 0;
            int contacto = 0;
            bool valido = false;

            do
            {
                try
                {
                    Console.WriteLine("\nIngrese el nombre del proveedor:");
                    nombre = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(nombre) || !nombre.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
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

            valido = false;
            do
            {
                try
                {
                    Console.WriteLine("Ingrese el número de identificación fiscal del proveedor:");
                    if (!int.TryParse(Console.ReadLine(), out id))
                    {
                        throw new Exception("El ID debe contener únicamente números.");
                    }

                    valido = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    valido = false;
                }
            } while (!valido);

            valido = false;
            do
            {
                try
                {
                    Console.WriteLine("Ingrese el contacto del proveedor:");
                    if (!int.TryParse(Console.ReadLine(), out contacto))
                    {
                        throw new Exception("El contacto debe contener únicamente números.");
                    }

                    valido = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    valido = false;
                }
            } while (!valido);

            Proveedor nuevoproveedor = new Proveedor(nombre, id, contacto);
            proveedores.Add(nuevoproveedor);

            Console.WriteLine("\n El proveedor fue registrado correctamente\n");
        }


        public void SeleccionarProveedor(List<Proveedor> proveedores)
        {
            if (proveedores.Count == 0)
            {
                Console.WriteLine("\n No hay proveedores registrados\n");
                return; // vuelve al menú principal
            }

            int opcion = 0;
            bool valido = false;

            do
            {
                try
                {
                    Console.WriteLine("\nSeleccione un proveedor de la lista:");

                    for (int i = 0; i < proveedores.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {proveedores[i].Nombre}");
                    }

                    string entrada = Console.ReadLine().Trim();
                    if (!int.TryParse(entrada, out opcion) || opcion < 1 || opcion > proveedores.Count)
                    {
                        throw new Exception("Debe ingresar un número válido entre 1 y " + proveedores.Count);
                    }


                    valido = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    valido = false;
                }
            } while (!valido);

            ProveedorSeleccionado = proveedores[opcion - 1];
            Console.WriteLine($"\n El proveedor seleccionado es: {ProveedorSeleccionado.Nombre}\n");
        }
    }
}
