using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    class Producto : INombre
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnidad { get; set; }
    
        public Producto(string nombre, string descripcion, decimal precio)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            PrecioUnidad = precio;
        }

        public void AgregarProducto(List<Producto> productos)
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
