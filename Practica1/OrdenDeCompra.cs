using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    public class OrdenDeCompra
    {
        public int NumUnico { get; set; }
        public int Fecha { get; set; }
        
        public OrdenDeCompra(int numUnico, int fecha) 
        {
            NumUnico = numUnico;
            Fecha = fecha; 
        }
    }
}
