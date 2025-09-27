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
        public int Id { get; set; }
        public int Contacto { get; set; }

        public Proveedor(string nombre, int id, int contacto)
        {
            Nombre = nombre;
            Id = id;    
            Contacto = contacto;
        }
        public static void RegistrarProveedor(List<Proveedor> proveedores) 
        {
            Console.WriteLine("\nIngrese el nombre del proveedor:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el número de identificación fiscal del proveedor:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el contacto del proveedor:");
            int contacto = int.Parse(Console.ReadLine());

            Proveedor nuevoproveedor = new Proveedor(nombre, id, contacto);
            proveedores.Add(nuevoproveedor);

            Console.WriteLine("\nEl proveedor fue registrado correctamente\n");
        }
    }
}
