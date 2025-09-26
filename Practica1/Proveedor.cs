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
        public void RegistrarProveedor(List<Proveedor> proveedores) 
        {
            Console.WriteLine("Ingrese el nombre del producto:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el número de identificación fiscal del proveedor:");
            string descripcion = (Console.ReadLine());

            Console.WriteLine("Ingrese el contacto del proveedor:");
            decimal precio = int.Parse(Console.ReadLine());

            Producto nuevoproducto = new Producto(nombre, descripcion, precio);
            productos.Add(nuevoproducto);

            Console.WriteLine("El producto fue registrado correctamente\n");
        }
    }
}
