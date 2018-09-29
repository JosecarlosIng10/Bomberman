using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    public class Tokens
    {

        public int num;
        public int fila;
        public int columna;
        public string tipo;
        public string idTipo;
        public string lexema;
        public string palabra;
        public Tokens Siguiente;

        public Tokens(int num, int fila, int columna, string tipo, string idTipo, string lexema,string palabra)
        {


            this.num = num;
            this.fila = fila;
            this.columna = columna;
            this.tipo = tipo;
            this.idTipo = idTipo;
            this.lexema = lexema;
            this.palabra = palabra;
            this.Siguiente = null;



        }
    }
}
