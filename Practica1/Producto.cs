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
            Console.WriteLine("Ingrese el nombre del producto:");
            Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese la descripción del producto:");
            Descripcion = (Console.ReadLine());

            Console.WriteLine("Ingrese el precio por unidad:");
            PrecioUnidad = decimal.Parse(Console.ReadLine());

            productos.Add(this); //se agrega la instancia a la lista principal

            Console.WriteLine("\nEl producto fue registrado correctamente\n");
        }
    }
}
