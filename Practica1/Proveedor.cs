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


        
    }
}
