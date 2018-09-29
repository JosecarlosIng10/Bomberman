using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomberman
{
     class Cola
    {

        public Tokens cabeza;
        public Tokens Ultimo;
        public Tokens Auxiliar;


       

         public  Cola()
        {
            cabeza = null;
            Ultimo = null;
            Auxiliar = null;



           

        }

        public void Insertar(Tokens nuevo)
        {

            if (cabeza == null)
            {

                cabeza = nuevo;

            }

            else if (Ultimo == null)
            {

                Ultimo = nuevo;
                cabeza.Siguiente = Ultimo;


            }
            else
            {
                Auxiliar = nuevo;
                Ultimo.Siguiente = Auxiliar;
                Ultimo = Auxiliar;


            }

        }

        public void eliminar()
        {

            while (cabeza != null)
            {


                Auxiliar = cabeza.Siguiente;
                cabeza = null;
                cabeza = Auxiliar;


            }

            Ultimo = null;


        }
        public int map = 1;
        public void mostrar()
        {
            Form1 principal = new Form1();

            Tokens actual = cabeza;
            string cadena;

            string auxiliar = "";
            while (actual != null)
            {
                cadena = actual.tipo + "   " + actual.lexema;

                string num = "<td>" + actual.num + "</td>";
                string fila = "<td>" + actual.fila + "</td>";
                string col = "<td>" + actual.columna + "</td>";
                string tipo = "<td>" + actual.lexema + "</td>";
                string id = "<td>" + actual.idTipo + "</td>";
                string lexema = "<td>" + actual.tipo + "</td>";
                string palabra = "<td>" + actual.palabra + "</td>";



                auxiliar = auxiliar + "<tr>" + num + fila + col + id + tipo + lexema + palabra + "</tr>";




                actual = actual.Siguiente;


            }


            var archivo = @"C:\Users\equipo\Desktop\Bomberman\Tablas\SIMBOLOS_" + map + ".html";
            map++;


            // eliminar el fichero si ya existe
            if (File.Exists(archivo))
                File.Delete(archivo);

            // crear el fichero
            using (var fileStream = File.Create(archivo))
            {
                DateTime localDate = DateTime.Now;
                var texto = new UTF8Encoding(true).GetBytes("<html><head><title>Lenguajes</title></head><body><h1>Jose Carlos Estrada Garcia</h1><h2>Carnet 201212644</h2><h3>" + localDate.ToString() + "</h3><table><tr align=" + "center" + " bottom=" + "middle" + "><table border=" + '1' + " cellpadding=" + '1' + " cellspacing=" + '1' + " ><table bordercolordark=" + "#999933" + " bordercolorlight=" + "#CCCC66" + " border=" + '8' + " cellpadding=" + '1' + " cellspacing=" + '1' + "><tr  bgcolor= " + "#00FFFF" + " ><td><strong>#</strong></td><td><strong>Fila</strong></td><td><strong>Columna</strong></td><td><strong>id</strong></td><td><strong>Lexema</strong></td><td><strong>Token</strong></td><td><strong>Palabra Reservada</strong></td></tr><tr>" + auxiliar + "</tr></table> </body></html>");
                fileStream.Write(texto, 0, texto.Length);
                fileStream.Flush();

            }


            auxiliar = "";

            //< html >< head >< title > Ejemplo de tabla sencilla </ title ></ head >< body >< h1 > Lenguajes </ h1 >< table >< tr >< td >< strong > Token </ strong ></ td >< td >< strong > Lexema </ strong ></ td ></ tr >< tr > " + auxiliar +   " </ tr ></ table > </ body ></ html >


        }

        ColaSintactico errorsin = new ColaSintactico();
        

        public void errorsintactico(int num, int fil, int col, string lexema, string tokenesperado)
        {

            Sintactico nuevo = new Sintactico(num, fil, col, lexema, tokenesperado);


            errorsin.Insertar(nuevo);





        }

        public void analizador()
        {
            errorsin.eliminar();

            int caso = 0;
            int num = 0;
            Auxiliar = cabeza;
            while (cabeza != null)
            {


                switch (caso)
                {
                    case 0:
                        if (cabeza.idTipo.Equals("V1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 1;


                        }
                        else if (cabeza.idTipo.Equals("J1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 11;


                        }
                        else if (cabeza.idTipo.Equals("C1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 31;


                        }
                        else if (cabeza.idTipo.Equals("A1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 138;


                        }
                        else if (cabeza.idTipo.Equals("E1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 118;


                        }
                        else
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 0;
                        }

                        break;
                    case 1:
                        if (cabeza.idTipo.Equals("V1V"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 2;

                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "< Var");




                            num++;
                            caso = 0;

                        }

                        break;
                    case 2:
                        if (cabeza.idTipo.Equals("V2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 2;

                        }

                        else if (cabeza.idTipo.Equals("V3"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 3;

                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Tipo");

                            num++;
                            caso = 0;
                        }


                        break;
                    case 3:
                        if (cabeza.idTipo.Equals("S1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 4;

                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "=");

                            num++;
                            caso = 0;
                        }


                        break;
                    case 4:
                        if (cabeza.idTipo.Equals("V31"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 5;

                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Tipo de Variable");

                            num++;
                            caso = 0;
                        }


                        break;
                    case 5:
                        if (cabeza.idTipo.Equals("V4"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 6;

                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Valor");

                            num++;
                            caso = 0;
                        }


                        break;
                    case 6:
                        if (cabeza.idTipo.Equals("S1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 7;

                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "=");

                            num++;
                            caso = 0;
                        }


                        break;
                    case 7:
                        if (cabeza.idTipo.Equals("V41"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 8;

                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Valor de la Variable");

                            num++;
                            caso = 0;
                        }


                        break;
                    case 8:
                        if (cabeza.idTipo.Equals("V5"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 9;

                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Nombre de la Variable");

                            num++;
                            caso = 0;
                        }


                        break;
                    case 9:
                        if (cabeza.idTipo.Equals("V6"))
                        {
                            if (cabeza.Siguiente.idTipo.Equals("V1V"))
                            {
                                cabeza = cabeza.Siguiente;
                                caso = 1;
                            }
                            else
                            {

                                cabeza = cabeza.Siguiente;
                                caso = 10;
                            }

                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Cierrre Etiqueta Var");

                            num++;
                            caso = 0;
                        }


                        break;
                    case 10:
                        if (cabeza.idTipo.Equals("V22"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 0;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Cierre Etiqueta Variables");

                            num++;
                            caso = 0;
                        }


                        break;






                    //Analizador Jugador




                    case 11:
                        if (cabeza.idTipo.Equals("U1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 12;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta Color");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 12:
                        if (cabeza.idTipo.Equals("S1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 13;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Signo Igual");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 13:
                        if (cabeza.idTipo.Equals("U11"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 14;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Color");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 14:
                        if (cabeza.idTipo.Equals("J3"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 15;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta traje: Jugador");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 15:
                        if (cabeza.idTipo.Equals("S1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 16;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Signo Igual");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 16:
                        if (cabeza.idTipo.Equals("J31"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 17;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Traje del Jugador");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 17:
                        if (cabeza.idTipo.Equals("J11"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 18;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de apertura: Vidas");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 18:
                        if (cabeza.idTipo.Equals("J111"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 20;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Valor de Vidas");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 20:
                        if (cabeza.idTipo.Equals("J112"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 21;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "ETiqueta de cierre: Vidas");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 21:
                        if (cabeza.idTipo.Equals("J12"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 22;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de apertura: Poder");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 22:
                        if (cabeza.idTipo.Equals("J121"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 23;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Valor de poder");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 23:
                        if (cabeza.idTipo.Equals("J122"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 24;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de cierre: Poder");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 24:
                        if (cabeza.idTipo.Equals("J13"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 25;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de apertura: Remoto");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 25:
                        if (cabeza.idTipo.Equals("J131"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 26;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Valor Remoto");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 26:
                        if (cabeza.idTipo.Equals("J132"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 27;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de cierre: Remoto");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 27:
                        if (cabeza.idTipo.Equals("J14"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 28;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de apertira: Fantasma");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 28:
                        if (cabeza.idTipo.Equals("J141"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 29;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Valor de fantasma");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 29:
                        if (cabeza.idTipo.Equals("J142"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 30;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de cierre: Fantasma");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 30:
                        if (cabeza.idTipo.Equals("J4"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 0;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de cierre: Jugador");

                            num++;
                            caso = 0;
                        }
                        break;


                    //Analizador sintactico de campo


                    case 31:
                        if (cabeza.idTipo.Equals("C2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 32;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta ancho:Campo");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 32:
                        if (cabeza.idTipo.Equals("S1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 33;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Signo Igual");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 33:
                        if (cabeza.idTipo.Equals("C21"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 34;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Ancho de Campo");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 34:
                        if (cabeza.idTipo.Equals("C3"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 35;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta alto:Campo");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 35:
                        if (cabeza.idTipo.Equals("S1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 36;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Signo Igual");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 36:
                        if (cabeza.idTipo.Equals("C31"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 37;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Alto de Campo");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 37:
                        if (cabeza.idTipo.Equals("U1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 38;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta color");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 38:
                        if (cabeza.idTipo.Equals("S1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 39;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Signo Igual");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 39:
                        if (cabeza.idTipo.Equals("U11"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 40;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Color");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 40:
                        if (cabeza.idTipo.Equals("U2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 41;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta Textura");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 41:
                        if (cabeza.idTipo.Equals("S1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 42;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Signo igual");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 42:
                        if (cabeza.idTipo.Equals("U21"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 43;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Textura");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 43:
                        if (cabeza.idTipo.Equals("CR1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 44;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de apertura:Rocas");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 44:
                        if (cabeza.idTipo.Equals("RR1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 45;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de apertura: Roca");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 45:
                        if (cabeza.idTipo.Equals("U1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 46;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta Color");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 46:
                        if (cabeza.idTipo.Equals("S1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 47;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Signo Igual");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 47:
                        if (cabeza.idTipo.Equals("U11"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 48;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Color");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 48:
                        if (cabeza.idTipo.Equals("U2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 49;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta textura");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 49:
                        if (cabeza.idTipo.Equals("S1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 50;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Signo igual");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 50:
                        if (cabeza.idTipo.Equals("U21"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 51;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Textura");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 51:
                        if (cabeza.idTipo.Equals("RR2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 52;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta durable:roca");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 52:
                        if (cabeza.idTipo.Equals("S1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 53;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Signo igual");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 53:
                        if (cabeza.idTipo.Equals("RR21"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 54;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Durabilidad de la roca");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 54:
                        if (cabeza.idTipo.Equals("X1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 55;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de apertura:X");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 55:
                        if (cabeza.idTipo.Equals("X11"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 56;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Valor de X");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 56:
                        if (cabeza.idTipo.Equals("X2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 57;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta cierre: X");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 57:
                        if (cabeza.idTipo.Equals("Y1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 58;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de apertura: Y");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 58:
                        if (cabeza.idTipo.Equals("Y11"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 59;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Valor de Y");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 59:
                        if (cabeza.idTipo.Equals("Y2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 60;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de cierre: Y");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 60:
                        if (cabeza.idTipo.Equals("RR3"))
                        {
                            if (cabeza.Siguiente.idTipo.Equals("RR1"))
                            {
                                cabeza = cabeza.Siguiente;
                                caso = 44;
                            }
                            else
                            {
                                cabeza = cabeza.Siguiente;
                                caso = 61;
                            }


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de cierre: Roca");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 61:
                        if (cabeza.idTipo.Equals("R2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 62;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de cierre: Rocas");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 62:
                        if (cabeza.idTipo.Equals("CT1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 63;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de apertura: Tesoros");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 63:
                        if (cabeza.idTipo.Equals("CTL1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 64;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta llave: Tesoro");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 64:
                        if (cabeza.idTipo.Equals("U1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 65;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta color");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 65:
                        if (cabeza.idTipo.Equals("S1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 66;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Signo igual");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 66:
                        if (cabeza.idTipo.Equals("U11"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 67;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Color");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 67:
                        if (cabeza.idTipo.Equals("U2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 68;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta textura");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 68:
                        if (cabeza.idTipo.Equals("S1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 69;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Signo igual");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 69:
                        if (cabeza.idTipo.Equals("U21"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 70;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Textura");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 70:
                        if (cabeza.idTipo.Equals("U3"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 71;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta accion");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 71:
                        if (cabeza.idTipo.Equals("S1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 72;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Signo igual");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 72:
                        if (cabeza.idTipo.Equals("U31"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 74;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Accion");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 74:
                        if (cabeza.idTipo.Equals("X1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 75;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de apertura:X");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 75:
                        if (cabeza.idTipo.Equals("X11"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 76;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Valor de X");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 76:
                        if (cabeza.idTipo.Equals("X2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 77;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta cierre: X");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 77:
                        if (cabeza.idTipo.Equals("Y1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 78;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de apertura: Y");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 78:
                        if (cabeza.idTipo.Equals("Y11"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 79;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Valor de Y");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 79:
                        if (cabeza.idTipo.Equals("Y2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 80;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de cierre: Y");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 80:
                        if (cabeza.idTipo.Equals("CTL2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 81;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de cierra: Llave");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 81:
                        if (cabeza.idTipo.Equals("CTB1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 82;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta bono: Tesoro");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 82:
                        if (cabeza.idTipo.Equals("U1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 83;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta color");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 83:
                        if (cabeza.idTipo.Equals("S1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 84;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Signo igual");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 84:
                        if (cabeza.idTipo.Equals("U11"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 85;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Color");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 85:
                        if (cabeza.idTipo.Equals("U2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 86;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta textura");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 86:
                        if (cabeza.idTipo.Equals("S1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 87;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Signo igual");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 87:
                        if (cabeza.idTipo.Equals("U21"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 88;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Textura");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 88:
                        if (cabeza.idTipo.Equals("U3"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 89;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta accion");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 89:
                        if (cabeza.idTipo.Equals("S1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 90;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Signo igual");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 90:
                        if (cabeza.idTipo.Equals("U31"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 91;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Accion");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 91:
                        if (cabeza.idTipo.Equals("X1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 92;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de apertura:X");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 92:
                        if (cabeza.idTipo.Equals("X11"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 93;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Valor de X");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 93:
                        if (cabeza.idTipo.Equals("X2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 94;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta cierre: X");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 94:
                        if (cabeza.idTipo.Equals("Y1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 95;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de apertura: Y");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 95:
                        if (cabeza.idTipo.Equals("Y11"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 96;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Valor de Y");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 96:
                        if (cabeza.idTipo.Equals("Y2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 97;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de cierre: Y");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 97:
                        if (cabeza.idTipo.Equals("CTB2"))
                        {
                            if (cabeza.Siguiente.idTipo.Equals("CTB1"))
                            {
                                cabeza = cabeza.Siguiente;
                                caso = 81;
                            }
                            else
                            {
                                cabeza = cabeza.Siguiente;
                                caso = 98;
                            }


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de cierre: Bono");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 98:
                        if (cabeza.idTipo.Equals("CTS1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 100;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta Salida: Tesoro");

                            num++;
                            caso = 0;
                        }
                        break;

                    case 100:
                        if (cabeza.idTipo.Equals("U1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 101;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta color");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 101:
                        if (cabeza.idTipo.Equals("S1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 102;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Signo igual");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 102:
                        if (cabeza.idTipo.Equals("U11"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 103;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Color");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 103:
                        if (cabeza.idTipo.Equals("U2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 104;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta textura");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 104:
                        if (cabeza.idTipo.Equals("S1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 105;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Signo igual");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 105:
                        if (cabeza.idTipo.Equals("U21"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 106;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Textura");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 106:
                        if (cabeza.idTipo.Equals("U3"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 107;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta accion");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 107:
                        if (cabeza.idTipo.Equals("S1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 108;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Signo igual");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 108:
                        if (cabeza.idTipo.Equals("U31"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 109;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Accion");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 109:
                        if (cabeza.idTipo.Equals("X1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 110;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de apertura:X");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 110:
                        if (cabeza.idTipo.Equals("X11"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 111;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Valor de X");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 111:
                        if (cabeza.idTipo.Equals("X2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 112;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta cierre: X");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 112:
                        if (cabeza.idTipo.Equals("Y1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 113;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de apertura: Y");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 113:
                        if (cabeza.idTipo.Equals("Y11"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 114;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Valor de Y");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 114:
                        if (cabeza.idTipo.Equals("Y2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 115;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de cierre: Y");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 115:
                        if (cabeza.idTipo.Equals("CTS2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 116;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de cierre: Salida");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 116:
                        if (cabeza.idTipo.Equals("T2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 117;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de cierre: Tesoro");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 117:
                        if (cabeza.idTipo.Equals("C5"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 0;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de cierre: Campo");

                            num++;
                            caso = 0;
                        }
                        break;



                    //Analizador Sintactico de Enemigos

                    case 118:
                        if (cabeza.idTipo.Equals("EE1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 119;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de Apertura Enemigo");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 119:
                        if (cabeza.idTipo.Equals("U1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 120;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta Color");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 120:
                        if (cabeza.idTipo.Equals("S1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 121;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Signo Igual");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 121:
                        if (cabeza.idTipo.Equals("U11"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 122;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Color");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 122:
                        if (cabeza.idTipo.Equals("U2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 123;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta textura");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 123:
                        if (cabeza.idTipo.Equals("S1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 124;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Signo igual");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 124:
                        if (cabeza.idTipo.Equals("U21"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 125;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Textura");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 125:
                        if (cabeza.idTipo.Equals("U5"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 126;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta X");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 126:
                        if (cabeza.idTipo.Equals("S1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 127;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Signo igual");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 127:
                        if (cabeza.idTipo.Equals("U51"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 128;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Posicion X");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 128:
                        if (cabeza.idTipo.Equals("U6"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 129;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta Y");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 129:
                        if (cabeza.idTipo.Equals("S1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 130;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Signo igual");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 130:
                        if (cabeza.idTipo.Equals("U61"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 131;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Posicion Y");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 131:
                        if (cabeza.idTipo.Equals("EEM1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 132;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de Apertura: Movimientos");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 132:
                        if (cabeza.idTipo.Equals("EEMM1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 133;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de apertura: Movimiento");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 133:
                        if (cabeza.idTipo.Equals("EEMM2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 134;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Valor del Movimiento");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 134:
                        if (cabeza.idTipo.Equals("EEMM3"))
                        {
                            if (cabeza.Siguiente.idTipo.Equals("EEMM1"))
                            {
                                cabeza = cabeza.Siguiente;
                                caso = 132;
                            }
                            else
                            {
                                cabeza = cabeza.Siguiente;
                                caso = 135;
                            }


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta cierre: Movimiento");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 135:
                        if (cabeza.idTipo.Equals("EEM2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 136;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de cierre: Movimientos");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 136:
                        if (cabeza.idTipo.Equals("EE2"))
                        {
                            if (cabeza.Siguiente.idTipo.Equals("EE1"))
                            {
                                cabeza = cabeza.Siguiente;
                                caso = 118;
                            }
                            else
                            {


                                cabeza = cabeza.Siguiente;
                                caso = 137;
                            }


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de cierre: Enemigo");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 137:
                        if (cabeza.idTipo.Equals("E2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 0;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de cierre: Enemigos");

                            num++;
                            caso = 0;
                        }
                        break;



                    //Analizador sintactico de acciones


                    case 138:
                        if (cabeza.idTipo.Equals("AA1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 139;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de apertura: Accion");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 139:
                        if (cabeza.idTipo.Equals("AA2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 140;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta ID: Accion");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 140:
                        if (cabeza.idTipo.Equals("S1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 141;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Signo igual");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 141:
                        if (cabeza.idTipo.Equals("AA3"))
                        {
                            if (cabeza.Siguiente.idTipo.Equals("CO3"))
                            {
                                cabeza = cabeza.Siguiente;
                                caso = 242;
                            }
                            else
                            {
                                cabeza = cabeza.Siguiente;
                                caso = 142;
                            }



                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Nombre de ID");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 242:
                        if (cabeza.idTipo.Equals("CO3"))
                        {
                            if (cabeza.Siguiente.idTipo.Equals("CO3"))
                            {
                                cabeza = cabeza.Siguiente;
                                caso = 242;
                            }
                            else
                            {
                                cabeza = cabeza.Siguiente;
                                caso = 147;
                            }


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Acciones y Operadores");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 142:
                        if (cabeza.idTipo.Equals("CO1"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 143;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Identificador Condicion");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 143:
                        if (cabeza.idTipo.Equals("CO2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 144;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Condicion");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 144:
                        if (cabeza.idTipo.Equals("U10"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 145;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Corchete Abierto");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 145:
                        if (cabeza.idTipo.Equals("CO3"))
                        {
                            if (cabeza.Siguiente.idTipo.Equals("CO3"))
                            {
                                cabeza = cabeza.Siguiente;
                                caso = 145;
                            }
                            else
                            {
                                cabeza = cabeza.Siguiente;
                                caso = 146;
                            }


                        }

                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Acciones y Operadores");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 146:
                        if (cabeza.idTipo.Equals("U11"))
                        {
                            if (cabeza.Siguiente.idTipo.Equals("CO1"))
                            {
                                cabeza = cabeza.Siguiente;
                                caso = 142;
                            }
                            else
                            {



                                cabeza = cabeza.Siguiente;
                                caso = 147;
                            }


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Corchete Cerrado");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 147:
                        if (cabeza.idTipo.Equals("AA4"))
                        {
                            if (cabeza.Siguiente.idTipo.Equals("AA1"))
                            {
                                cabeza = cabeza.Siguiente;
                                caso = 138;
                            }
                            else
                            {
                                cabeza = cabeza.Siguiente;
                                caso = 148;
                            }

                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de cierre: Accion");

                            num++;
                            caso = 0;
                        }
                        break;
                    case 148:
                        if (cabeza.idTipo.Equals("A2"))
                        {
                            cabeza = cabeza.Siguiente;
                            caso = 0;


                        }
                        else
                        {
                            errorsintactico(num, cabeza.fila, cabeza.columna, cabeza.lexema, "Etiqueta de cierre: Acciones");

                            num++;
                            caso = 0;
                        }
                        break;




                }




            }

            errorsin.mostrar();
            cabeza = Auxiliar;
        }

        public void dibujarenemigo(Form forma)
        {
            String color = "";
            String textura = "";
            int x = 0;
            int y = 0;
            int caso = 0;
            Auxiliar = cabeza;
            while (cabeza != null)
            {


                switch (caso)
                {
                    case 0:
                        if (cabeza.idTipo.Equals("EE1"))
                        {
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            color = cabeza.lexema;

                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            textura = cabeza.lexema;

                            Size a = new Size(27,27);

                            Image r = Image.FromFile(textura);
                            Bitmap newImage = new Bitmap(r,a);
                            

                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            x = Convert.ToInt32(cabeza.lexema);

                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            y = Convert.ToInt32(cabeza.lexema);

                            x = 40 + (31 * (x));
                            y = 60 + (31 * (y));
                            grafico.enemigo(forma, newImage, Color.FromName(color), x, y);

                        }
                        else
                        {
                            cabeza = cabeza.Siguiente;
                        }
                        break;
                }
            }

            cabeza = Auxiliar;


   }
        public int vidas()
        {
            int vidas = 0;
            int caso = 0;
            Auxiliar = cabeza;




            while (cabeza != null)
            {


                switch (caso)
                {
                    case 0:
                        if (cabeza.idTipo.Equals("J111"))
                        {
                            vidas = Convert.ToInt32(cabeza.lexema);
                            cabeza = cabeza.Siguiente;
                        }
                        else
                        {
                            cabeza = cabeza.Siguiente;
                        }
                        break;
                }
            }

            cabeza = Auxiliar;
            return vidas;
            
        }


        public void dibujartesoros(Form forma)
        {
            String color = "";
            String textura = "";

            String colorllave = "";
            String texturallave = "";
            int xllave = 0;
            int yllave = 0;

            String colorsalida = "";
            String colortextura = "";
            int xtxt = 0;
            int ytxt = 0;

            String colorroca = "";
            String txtroca = "";

            int x = 0;
            int y = 0;
            int caso = 0;
            Auxiliar = cabeza;
           

                     
            
            while (cabeza != null)
            {


                switch (caso)
                {
                    case 0:
                        if (cabeza.idTipo.Equals("RR1"))
                        {
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            colorroca = cabeza.lexema;


                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            txtroca = cabeza.lexema;
                            

                        }

                        if (cabeza.idTipo.Equals("CTB1"))
                        {
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            color = cabeza.lexema;

                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            textura = cabeza.lexema;

                            Size a = new Size(27, 27);

                            Image r = Image.FromFile(textura);
                            Bitmap newImage = new Bitmap(r, a);


                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            x = Convert.ToInt32(cabeza.lexema);

                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            y = Convert.ToInt32(cabeza.lexema);

                            x = 40 + (31 * (x));
                            y = 60 + (31 * (y));

                            
                            Image rok = Image.FromFile(txtroca);
                            Bitmap roca = new Bitmap(rok, a);

                            grafico.tesoro(forma, newImage, Color.FromName(color), x, y, Color.FromName(colorroca), roca);

                        }
                        else if (cabeza.idTipo.Equals("CTL1"))
                        {
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            colorllave = cabeza.lexema;

                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            texturallave = cabeza.lexema;

                            Size a = new Size(27, 27);

                            Image r = Image.FromFile(texturallave);
                            Bitmap newImage = new Bitmap(r, a);


                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            xllave = Convert.ToInt32(cabeza.lexema);

                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            yllave = Convert.ToInt32(cabeza.lexema);

                            xllave = 40 + (31 * (xllave));
                            yllave = 60 + (31 * (yllave));

                            Image rok = Image.FromFile(txtroca);
                            Bitmap roca = new Bitmap(rok, a);
                            grafico.tesoro(forma, newImage, Color.FromName(colorllave), xllave, yllave, Color.FromName(colorroca), roca);

                        }
                        else if (cabeza.idTipo.Equals("CTS1"))
                        {
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            colorsalida = cabeza.lexema;

                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            colortextura= cabeza.lexema;

                            Size a = new Size(27, 27);

                            Image r = Image.FromFile(colortextura);
                            Bitmap newImage = new Bitmap(r, a);


                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            xtxt = Convert.ToInt32(cabeza.lexema);

                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            ytxt = Convert.ToInt32(cabeza.lexema);

                            xtxt = 40 + (31 * (xtxt));
                            ytxt = 60 + (31 * (ytxt));

                            Image rok = Image.FromFile(txtroca);
                            Bitmap roca = new Bitmap(rok, a);
                            grafico.tesoro(forma, newImage, Color.FromName(colortextura), xtxt, ytxt, Color.FromName(colorroca), roca);

                        }
                        else
                        {
                            cabeza = cabeza.Siguiente;
                        }
                        break;
                       
                }
            }
            cabeza = Auxiliar;
        }
      
        public String[] dibujarcampo(Form forma)
        {

            bool blanco = true;
            int anchoCuadricula = 30;
            int x = 40, y = 60;


            int caso = 0;
            int ancho = 0;
            int largo = 0;
            String color = "";
            String colorjugador = "";
            String textura = "";
            string texturajugador = "";
            String colorroca = "";
            String txtroca = "";


            Auxiliar = cabeza;
            while (cabeza != null)
            {


                switch (caso)
                {
                    case 0:
                        if (cabeza.idTipo.Equals("J31"))
                        {
                            texturajugador = cabeza.lexema;
                            cabeza = cabeza.Siguiente;
                          
                        }
                      
                       else  if (cabeza.idTipo.Equals("RR1"))
                        {
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            colorroca = cabeza.lexema;


                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            txtroca = cabeza.lexema;

                            Size a = new Size(27, 27);

                            Image r = Image.FromFile(txtroca);
                            Bitmap newImage = new Bitmap(r, a);

                           
                            

                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            int xroca = Convert.ToInt32(cabeza.lexema);

                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;

                            int yroca = Convert.ToInt32(cabeza.lexema);

                            xroca = 40 + (31 * (xroca));
                            yroca = 60 + (31 * (yroca));

                            grafico.roca(forma, newImage, Color.FromName(colorroca), xroca, yroca);

                        }
                       else if (cabeza.idTipo.Equals("J1"))
                        {
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            colorjugador= cabeza.lexema;

                        }


                       else if (cabeza.idTipo.Equals("C1"))
                        {
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            ancho = Convert.ToInt32(cabeza.lexema) + 1;

                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            largo = Convert.ToInt32(cabeza.lexema) + 1;

                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            color = cabeza.lexema;

                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            cabeza = cabeza.Siguiente;
                            textura = cabeza.lexema;



                            if ((largo % 2) == 0)
                            {
                                largo++;
                            }
                            if ((ancho % 2) == 0)
                            {
                                ancho++;
                            }


                            for (int v = 0; v < largo; v++)
                            { 
                                for (int h = 0; h< ancho; h++)
                                    
                                {
                                   
                                    Bitmap camp = new Bitmap(""+textura+"");
                                    
                                    if (((h % 2) == 0) && ((v % 2) == 0))
                                    {
                                        grafico.GraficarCuadro(forma, Color.FromName("gray"), x, y, anchoCuadricula);
                                        blanco = false;
                                    }
                                    else
                                    {
                                        grafico.campo(forma, Color.FromName(color), x, y, anchoCuadricula, camp);
                                        blanco = true;
                                    }


                                  

                                    

    



                                    if ((h == 0) || (v == 0) || ((v + 1) == largo) || ((h + 1) == ancho))
                                    {
                                        
                                        grafico.GraficarCuadro(forma, Color.FromName("gray"), x, y, anchoCuadricula);
                                    }

                                    x += 31;

                                }
                                if (blanco)
                                    blanco = false;
                                else
                                    blanco = true;
                                x = 40;
                                y += 31;
                            }


                            Bitmap a = new Bitmap("" + texturajugador + "");


                            grafico.jugador(forma, Color.FromName(colorjugador), 71, 91, anchoCuadricula, a);
                            cabeza = cabeza.Siguiente;
                        }
                        else
                        {
                            cabeza = cabeza.Siguiente;
                        }

                        caso = 0;
                        break;


                }
            }

            String[] array = new String[6];

            array[0] = largo.ToString();
            array[1] = ancho.ToString();
            array[2] = textura;
            array[3] = texturajugador;
            array[4] = color;
            array[5] = colorjugador;

            cabeza = Auxiliar;
            return array;
        }

    }
}