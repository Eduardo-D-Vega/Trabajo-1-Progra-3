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

        public void RegistrarProveedor
    }
}
