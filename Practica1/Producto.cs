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

        public Producto(string nombre, string descripcion, decimal precio)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            PrecioUnidad = precio;
        }

        public void RegistrarProducto(List<Producto> productos)
        {
            Console.WriteLine("Ingrese el nombre del producto\n");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese la descripción del producto\n");
            string descripcion = (Console.ReadLine());

            Console.WriteLine("Ingrese el precio por unidad\n");
            decimal precio = decimal.Parse(Console.ReadLine());

            Producto nuevoproducto = new Producto(nombre, descripcion, precio);
            productos.Add(nuevoproducto);

            Console.WriteLine("El producto fue registrado correctamente\n");
        }
    }
}
