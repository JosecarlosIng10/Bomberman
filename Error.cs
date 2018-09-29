using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    public class Error
    {

        public int num;
        public int fila;
        public int columna;
        public string caracter;
        public string descripcion;

        public Error Siguiente;

        public Error(int num, int fila, int columna, string caracter, string descripcion)
        {


            this.num = num;
            this.fila = fila;
            this.columna = columna;
            this.caracter = caracter;
            this.descripcion = descripcion;
            this.Siguiente = null;



        }

    }
}
