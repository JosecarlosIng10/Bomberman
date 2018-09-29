using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    public class Sintactico
    {
        public int num;
        public int fila;
        public int columna;
        public string lexema;
        public string tokenesperado;

        public Sintactico Siguiente;

        public Sintactico(int num, int fila, int columna, string lexema, string tokenesperado)
        {


            this.num = num;
            this.fila = fila;
            this.columna = columna;
            this.lexema = lexema;
            this.tokenesperado = tokenesperado;
            this.Siguiente = null;



        }
    }
}
