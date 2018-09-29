using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomberman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }






        Form3 grafic = new Form3();
       
        public void dibujar()
        {
            

            grafic.StartPosition = FormStartPosition.CenterScreen;
            grafic.Show();
            grafic.Refresh();

            

            String[] array = new String[5];
            array = Token.dibujarcampo(grafic);
            Token.dibujarenemigo(grafic);
            Token.dibujartesoros(grafic);
            int altocampo = Convert.ToInt32(array[0]);
            int anchocampo = Convert.ToInt32(array[1]);
            String textcamp = array[2];
            String textjug = array[3];
            String colr = array[4];
            String colj = array[5];
           
            grafic.asignarvalores(altocampo, anchocampo, textcamp, textjug, colr, colj,vidas);
            
            timer1.Enabled = true;
        }
       
        public void copiararchivo(string dir)
        {
            string cadena = "";
            string line;
            System.IO.StreamReader file =
    new System.IO.StreamReader(dir);

            while ((line = file.ReadLine()) != null)
            {

                line=line.Replace("\t", "");
                cadena = cadena + line + "\n";


            }
            richTextBox1.Text = cadena;


           


            file.Close();


        }


        public void leerarchivo(string direccion)
        {



            string[] array = richTextBox1.Lines;


            for (int cont = 0; cont < array.Length; cont++)
            {

                analisis(array[cont]);
                fil++;
            }








        }
       


        public void analisis(String entrada)
        {
            entrada = entrada + "#";
            entrada = entrada.Replace(" ", "");
            string mayus = entrada;
            entrada = entrada.ToLower();
            int x = 0;


             int caso = 0;
         string auxiliar = "";

         string cerradura = "";


         Boolean valor = false;
         Boolean color = false;
         Boolean traje = false;
         Boolean ancho = false;
         Boolean alto = false;
         Boolean textura = false;
         Boolean durable = false;
         Boolean accion = false;
         Boolean xpos = false;
         Boolean ypos = false;
         Boolean id = false;

         string condicion = "";


         string operador1 = "";
         string operador2 = "";

         string operador3 = "";
         string operador4 = "";
         string cad1 = "";
            
           

            while (x < entrada.Length)
            {
                
                char a = entrada[x];
                char b = mayus[x];
               
                switch (caso)
                   
                {
                    case 0:

                        if (a == '<')
                        {

                            x++;
                            //auxiliar = auxiliar + entrada[x];
                            caso = 1;
                        }


                        else if (a == '>')
                        {
                            x++;
                            caso = 18;

                        }





                        else if (a == ' ')
                        {
                            x++;

                        }

                        else if (a == '#')
                        {
                            x++;

                        }
                        else if (a == '=')
                        {
                            guardartoken(no, fil, x - 1, "Signo Igual", "S1", "=", "No");
                            x++;
                            no++;
                            auxiliar = "";
                            caso = 0;

                        }
                        else if (a == '"')
                        {


                            //auxiliar = auxiliar + a;
                            x++;
                            caso = 1;
                        }
                        else if (a == '#')
                        {



                            x++;
                            caso = 0;
                        }
                        else if (a=='x')
                        {
                            guardartoken(no, fil, x - 1, "Etiqueta x", "U5", " X ", "Si");

                            x++;
                            no++;
                            auxiliar = "";
                            xpos = true;
                            caso = 15;
                        }
                        else if (a == 'y')
                        {
                            guardartoken(no, fil, x - 1, "Etiqueta y", "U6", " Y ", "Si");

                            x++;
                            no++;
                            auxiliar = "";


                            ypos = true;
                            caso = 15;
                        }

                        else if (char.IsLetter(a))
                        {

                            auxiliar = auxiliar + a;
                            x++;
                            caso = 1;

                        }
                        else if (a == '(')
                        {

                            x++;
                            caso = 23;
                        }
                        else if (a == '{')
                        {
                            

                            caso = 26;
                        }
                        else if (a == '}')
                        {

                           
                           
                            caso = 30;

                        }
                        else
                        {
                            guardarerror(noe, fil,x, a+"", "Caracter desconocido");
                            noe++;
                            x=entrada.Length;
                        }
                        break;

                    case 1:
                       
                        if (a=='x')
                        {
                            guardartoken(no, fil, x-1, "Etiqueta de apertura: x", "X1", "<x>", "Si");

                            x++;
                            no++;
                            auxiliar = "";
                            caso = 0;
                        }
                        else if (a=='y')
                        {
                            guardartoken(no, fil, x -1, "Etiqueta de apertura: y", "Y1", "<y>", "Si");

                            x++;
                            no++;
                            auxiliar = "";
                            caso = 0;
                        }
                        else if (char.IsLetter(a))
                        {

                            auxiliar = auxiliar + a;
                            x++;
                            caso = 2;

                        }
                        else if (a=='%')
                        {

                            x++;
                            caso = 20;

                        }
                       else
                        {
                            guardarerror(noe, fil, x, a + "", "Caracter desconocido");
                            noe++;
                            x = entrada.Length;
                        }


                        break;
                    case 2:
                         if (auxiliar.ToLower().Equals("id"))
                        {
                            guardartoken(no, fil, x - 4, "Etiqueta Id: Accion", "AA2", "id", "Si");

                            no++;
                            auxiliar = "";
                            id = true;
                            caso = 15;
                        }
                         else if ((a=='n') && (entrada[x + 1].Equals('o'))){
                             auxiliar = auxiliar + a;
                            x++;
                            caso = 3;
                        }
                        else if (auxiliar.ToLower().Equals("si"))
                        {


                            caso = 22;
                        }
                        else if (char.IsLetter(a))
                        {

                            auxiliar = auxiliar + a;
                            x++;
                            caso = 3;

                        }
                       
                        else
                        {
                            guardarerror(noe, fil, x, a + "", "Caracter desconocido");
                            noe++;
                            x = entrada.Length;
                        }



                        break;
                    case 3:
                        if (char.IsLetter(a))
                        {

                            auxiliar = auxiliar + a;
                            x++;
                            caso = 4;

                        }
                        
                        else
                        {
                            guardarerror(noe, fil, x, a + "", "Caracter desconocido");
                            noe++;
                            x = entrada.Length;
                        }



                        break;
                    case 4:
                        if (auxiliar.ToLower().Equals("var"))
                        {
                            if (entrada[x] == 'i')
                            {
                                auxiliar = auxiliar + a;
                                x++;
                                caso = 5;

                            }
                            else
                            {
                                guardartoken(no, fil, x - 3, "Etiqueta apertura: Variable", "V1V", "< var >", "Si");

                                no++;
                                auxiliar = "";
                                caso = 0;
                            }
                           
                        }
                     else if (auxiliar.ToLower().Equals("sino")) 
                        {
                            condicion = "--";
                         
                            caso = 22;
                        }

                        else if (auxiliar.ToLower().Equals("tipo"))
                        {
                            guardartoken(no, fil, x - 4, "Etiqueta tipo: Variable", "V3", "tipo", "Si");

                            no++;
                            auxiliar = "";
                            caso = 0;
                        }
                        else if (auxiliar.ToLower().Equals("alto"))
                        {
                            guardartoken(no, fil, x - 4, "Etiqueta alto: Campo", "C3", "alto", "Si");

                            no++;
                            auxiliar = "";
                            alto = true;
                            caso = 15;
                        }
                        else if (char.IsLetter(entrada[x]))
                        {

                            auxiliar = auxiliar + a;
                            x++;
                            caso = 5;

                        }
                        else
                        {
                            guardarerror(noe, fil, x, a + "", "Caracter desconocido");
                            noe++;
                            x = entrada.Length;
                        }



                        break;
                    case 5:
                        if (auxiliar.ToLower().Equals("valor"))
                        {
                            guardartoken(no, fil, x - 5, "Etiqueta Valor: Variable", "V4", "valor", "Si");

                            no++;
                            auxiliar = "";
                            valor = true;
                            caso = 15;
                        }
                       else if (auxiliar.ToLower().Equals("color"))
                        {
                            guardartoken(no, fil, x - 5, "Etiqueta color","U1","color" , "Si");

                            no++;
                            auxiliar = "";
                            color = true;
                            caso = 15;
                        }
                        else if (auxiliar.ToLower().Equals("traje"))
                        {
                            guardartoken(no, fil, x - 5, "Etiqueta traje: Jugador", "J3", "traje", "Si");

                            no++;
                            auxiliar = "";
                            traje = true;
                            caso = 15;
                        }
                        else if (auxiliar.ToLower().Equals("ancho"))
                        {
                            guardartoken(no, fil, x - 5, "Etiqueta ancho: Campo", "C2", "ancho", "Si");

                            no++;
                            auxiliar = "";
                            ancho = true;
                            caso = 15;
                        }
                        else if (auxiliar.ToLower().Equals("roca"))
                        {

                            if (entrada[x] == 's')
                            {
                                auxiliar = auxiliar + 's';
                                x = x + 1;
                                caso = 6;

                            }
                            else
                            {
                                guardartoken(no, fil, x - 4, "Etiqueta de apertura: roca", "RR1", "< roca >", "Si");

                                no++;
                                auxiliar = "";

                                caso = 0;
                            }
                        }
                        else if (auxiliar.ToLower().Equals("bono"))
                        {
                            guardartoken(no, fil, x - 4, "Etiqueta bono: Tesoro", "CTB1", "bono", "Si");

                            no++;
                            auxiliar = "";
                            caso = 0;
                        }
                        else if (char.IsLetter(entrada[x]))
                        {

                            auxiliar = auxiliar + a;
                            x++;
                            caso = 6;

                        }
                        else
                        {
                            guardarerror(noe, fil, x, a + "", "Caracter desconocido");
                            noe++;
                            x = entrada.Length;
                        }



                        break;
                    case 6:
                        if (auxiliar.ToLower().Equals("global"))
                        {
                            guardartoken(no, fil, x - 6, "Accesibilidad de la Variable", "V2", "global", "Si");

                            no++;
                            auxiliar = "";
                            caso = 0;
                        }
                        else if (auxiliar.ToLower().Equals("vidas"))
                        {
                            guardartoken(no, fil, x - 5, "Etiqueta de apertura: Vidas", "J11", "< vidas >", "Si");

                            no++;
                            auxiliar = "";
                            caso = 0;
                        }
                        else if (auxiliar.ToLower().Equals("poder"))
                        {
                            guardartoken(no, fil, x - 5, "Etiqueta de apertura: poder", "J12", "< poder >", "Si");

                            no++;
                            auxiliar = "";
                            caso = 0;
                        }
                        else if (auxiliar.ToLower().Equals("campo"))
                        {
                            guardartoken(no, fil, x - 5, "Etiqueta de apertura: campo", "C1", "< campo >", "Si");

                            no++;
                            auxiliar = "";
                            caso = 0;
                        }
                        else if (auxiliar.ToLower().Equals("rocas"))
                        {
                            guardartoken(no, fil, x - 5, "Etiqueta de apertura: rocas", "CR1", "< rocas >", "Si");

                            no++;
                            auxiliar = "";
                            caso = 0;
                        }
                        else if (auxiliar.ToLower().Equals("llave"))
                        {
                            guardartoken(no, fil, x - 5, "Etiqueta llave: Tesoro", "CTL1", "llave", "Si");

                            no++;
                            auxiliar = "";
                            caso = 0;
                        }
                        else if (auxiliar.ToLower().Equals("accion"))
                        {
                            guardartoken(no, fil, x - 6, "Etiqueta accion", "U3", "accion", "Si");
                            no++;
                            auxiliar = "";
                            accion = true;
                            caso = 15;
                        }
                        else if (char.IsLetter(entrada[x]))
                        {

                            auxiliar = auxiliar + a;
                            x++;
                            caso = 7;

                        }
                        else
                        {
                            guardarerror(noe, fil, x, a + "", "Caracter desconocido");
                            noe++;
                            x = entrada.Length;
                        }



                        break;
                    case 7:
                        if (auxiliar.ToLower().Equals("remoto"))
                        {
                            guardartoken(no, fil, x - 6, "Etiqueta de apertura: remoto", "J13", "< remoto >", "Si");

                            no++;
                            auxiliar = "";
                            caso = 0;
                        }
                        else if (auxiliar.ToLower().Equals("textura"))
                        {
                            guardartoken(no, fil, x - 7, "Etiqueta textura", "U2", "textura", "Si");

                            no++;
                            auxiliar = "";
                            textura = true;
                            caso = 15;
                        }
                        else if (auxiliar.ToLower().Equals("durable"))
                        {
                            guardartoken(no, fil, x - 7, "Etiqueta durable: roca", "RR2", "durable", "Si");

                            no++;
                            auxiliar = "";
                            durable = true;
                            caso = 15;
                        }
                        
                        else if (auxiliar.ToLower().Equals("salida"))
                        {
                            guardartoken(no, fil, x - 5, "Etiqueta Salida: Tesoro", "CTS1", "salida", "Si");

                            no++;
                            auxiliar = "";
                            caso = 0;
                        }
                        else if (auxiliar.ToLower().Equals("accion"))
                        {

                            if ((entrada[x] == 'e') && (entrada[x+1] == 's'))
                            {
                                auxiliar = auxiliar + "es";
                                x = x + 2;
                                caso = 9;

                            }
                            else
                            {
                                guardartoken(no, fil, x - 6, "Etiqueta de apertura: accion", "AA1", "< accion >", "Si");

                                no++;
                                auxiliar = "";

                                caso = 0;
                            }
                        }


                        else if (a == '"')
                        {

                            caso = 8;
                        }
                        else if (char.IsLetter(entrada[x]))
                        {
                            auxiliar = auxiliar + a;
                            x++;
                            caso = 8;

                        }
                        else
                        {
                            guardarerror(noe, fil, x, a + "", "Caracter desconocido");
                            noe++;
                            x = entrada.Length;
                        }


                        break;
                    case 8:
                        if (auxiliar.ToLower().Equals("cadena"))
                        {
                            guardartoken(no, fil, x - 6, "Tipo de Variable", "V31", '"' + "cadena" + '"', "Si");
                            x++;
                            no++;
                            auxiliar = "";
                            caso = 0;
                        }
                        else if (auxiliar.ToLower().Equals("entero"))
                        {
                            guardartoken(no, fil, x - 6, "Tipo de Variable", "V31", '"' + "entero" + '"', "Si");
                            x++;
                            no++;
                            auxiliar = "";
                            caso = 0;
                        }
                        else if (auxiliar.ToLower().Equals("jugador"))
                        {
                            guardartoken(no, fil, x - 7, "Etiqueta apertura: Jugador", "J1", "< jugador >", "Si");

                            no++;
                            auxiliar = "";
                            caso = 0;
                        }
                        else if (auxiliar.ToLower().Equals("tesoros"))
                        {
                            guardartoken(no, fil, x - 7, "Etiqueta de apertura: tesoro", "CT1", "< tesoros >", "Si");

                            no++;
                            auxiliar = "";
                            caso = 0;
                        }
                        else if (auxiliar.ToLower().Equals("enemigo"))
                        {

                            if (entrada[x] == 's')
                            {
                                auxiliar = auxiliar + 's';
                                x = x + 1;
                                caso = 9;

                            }
                            else
                            {
                                guardartoken(no, fil, x - 7, "Etiqueta de apertura: Enemigo", "EE1", "< enemigo >", "Si");

                                no++;
                                auxiliar = "";

                                caso = 0;
                            }
                        }
                        else if (auxiliar.ToLower().Equals("ademassi"))
                        {


                            caso = 22;
                        }
                        else if (char.IsLetter(entrada[x]))
                        {
                            auxiliar = auxiliar + a;
                            x++;
                            caso = 9;

                        }
                        
                        else
                        {
                            guardarerror(noe, fil, x, a + "", "Caracter desconocido");
                            noe++;
                            x = entrada.Length;
                        }



                        break;
                    case 9:
                         if (auxiliar.ToLower().Equals("fantasma"))
                        {
                            guardartoken(no, fil, x - 8, "Etiqueta de apertura: fantasma", "J14", "< fantasma >", "Si");

                            no++;
                            auxiliar = "";
                            caso = 0;
                        }
                        else if (auxiliar.ToLower().Equals("enemigos"))
                        {
                            guardartoken(no, fil, x - 5, "Etiqueta de apertura: enemigos", "E1", "< enemigos >", "Si");

                            no++;
                            auxiliar = "";
                            caso = 0;
                        }
                        else if (auxiliar.ToLower().Equals("acciones"))
                        {
                            guardartoken(no, fil, x - 8, "Etiqueta de apertura: acciones", "A1", "< acciones >", "Si");

                            no++;
                            auxiliar = "";
                            caso = 0;
                        }
                        else if (a == '"')
                        {

                            caso = 10;
                        }
                        else if (char.IsLetter(entrada[x]))
                        {
                            auxiliar = auxiliar + a;
                            x++;
                            caso = 10;

                        }
                        else
                        {
                            guardarerror(noe, fil, x, a + "", "Caracter desconocido");
                            noe++;
                            x = entrada.Length;
                        }




                        break;
                    case 10:

                        if (auxiliar.ToLower().Equals("booleano"))
                        {
                            guardartoken(no, fil, x - 8, "Tipo de Variable", "V31", '"' + "booleano" + '"', "Si");
                            x++;
                            no++;
                            auxiliar = "";
                            caso = 0;
                        }
                        else if (auxiliar.ToLower().Equals("variables"))
                        {
                            guardartoken(no, fil, x - 10, "Etiqueta de apertura: Variables", "V1", "< variables ", "Si");

                            no++;
                            auxiliar = "";
                            caso = 0;
                        }
                        else if (char.IsLetter(entrada[x]))
                        {
                            auxiliar = auxiliar + a;
                            x++;
                            caso = 11;

                        }
                        else
                        {
                            guardarerror(noe, fil, x, a + "", "Caracter desconocido");
                            noe++;
                            x = entrada.Length;
                        }


                        break;
                    case 11:
                          if (auxiliar.ToLower().Equals("movimiento"))
                        {

                            if (entrada[x] == 's')
                            {
                                auxiliar = auxiliar + 's';
                                x = x + 1;
                                caso = 12;

                            }
                            else
                            {
                                guardartoken(no, fil, x - 10, "Etiqueta de apertura: Movimiento", "EEMM1", "< movimiento >", "Si");

                                no++;
                                auxiliar = "";

                                caso = 0;
                            }
                        }
                        else if (char.IsLetter(entrada[x]))
                        {
                            auxiliar = auxiliar + a;
                            x++;
                            caso = 12;

                        }
                        else
                        {
                            guardarerror(noe, fil, x, a + "", "Caracter desconocido");
                            noe++;
                            x = entrada.Length;
                        }


                        break;
                    case 12:
                         if (auxiliar.ToLower().Equals("movimientos"))
                        {
                            guardartoken(no, fil, x - 12, "Etiqueta de apertura: Movimientos", "EEM1", "< movimientos >", "Si");

                            no++;
                            auxiliar = "";
                            caso = 0;
                        }
                        else if (char.IsLetter(entrada[x]))
                        {
                            auxiliar = auxiliar + a;
                            guardarerror(noe, fil, x,auxiliar, "Cadena desconocido");
                            noe++;
                            x = entrada.Length;
                            x++;
                            //caso = ;

                        }
                        else
                        {
                            guardarerror(noe, fil, x, auxiliar, "Cadena desconocido");
                            noe++;
                            x = entrada.Length;
                        }


                        break;


                    // cierre







                    //Valor de las variables

                    case 15:
                        if (a == '=')
                        {
                            guardartoken(no, fil, x - 1, "Signo Igual", "S1", "=", "No");
                            x++;
                            no++;
                            caso = 16;

                        }
                        else
                        {
                            guardarerror(noe, fil, x, a + "", "Caracter desconocido");
                            noe++;
                            x = entrada.Length;
                        }


                        break;
                    case 16:
                        if (a == '"')
                        {
                            x++;
                            caso = 17;

                        }
                        else
                        {
                            guardarerror(noe, fil, x, a + "", "Caracter desconocido");
                            noe++;
                            x = entrada.Length;
                        }


                        break;
                    case 17:
                        if (a == '"')
                        {

                            if (valor == true)
                            {
                               
                                    guardartoken(no, fil, x - auxiliar.Length, "Valor de Variable ", "V41", auxiliar, "No");
                                    auxiliar = "";
                                    x++;
                                    no++;
                                    valor = false;
                                    caso = 0;
                                
                              
                               
                            }
                            else if (color == true)
                            {
                                try
                                {
                                    int tr=Convert.ToInt32(auxiliar);
                                    guardartoken(no, fil, x - auxiliar.Length, "Color", "U0S", auxiliar, "No");
                                    auxiliar = "";
                                    x++;
                                    no++;
                                    color = false;
                                    caso = 0;
                                }
                                catch
                                {
                                    guardartoken(no, fil, x - auxiliar.Length, "Color", "U11", auxiliar, "No");
                                    auxiliar = "";
                                    x++;
                                    no++;
                                    color = false;
                                    caso = 0;
                                }
                                
                            }
                            else if (traje == true)
                            {
                                guardartoken(no, fil, x - auxiliar.Length, "Traje del jugador ", "J31", auxiliar, "No");
                                auxiliar = "";

                                x++;
                                no++;
                                traje = false;
                                caso = 0;
                            }
                            else if (alto == true)
                            {
                                guardartoken(no, fil, x - auxiliar.Length, "Alto del Campo ", "C31", auxiliar, "No");
                                auxiliar = "";
                                x++;
                                no++;
                                alto = false;
                                caso = 0;
                            }
                            else if (ancho == true)
                            {
                                guardartoken(no, fil, x - auxiliar.Length, "Ancho del Campo ", "C21", auxiliar, "No");
                                auxiliar = "";
                                x++;
                                no++;
                                ancho = false;
                                caso = 0;
                            }
                            else if (textura == true)
                            {
                                guardartoken(no, fil, x - auxiliar.Length, "Textura", "U21", auxiliar, "No");
                                auxiliar = "";
                                x++;
                                no++;
                                textura = false;
                                caso = 0;
                            }
                            else if (durable == true)
                            {
                                
                                    guardartoken(no, fil, x - auxiliar.Length, "Durabilidad de la roca ", "RR21", auxiliar, "No");
                                    auxiliar = "";
                                    x++;
                                    no++;
                                    durable = false;
                                    caso = 0;
                               
                            }
                            else if (accion == true)
                            {
                                guardartoken(no, fil, x - auxiliar.Length, "Accion", "U31", auxiliar, "No");
                                auxiliar = "";
                                x++;
                                no++;
                                accion = false;
                                caso = 0;
                            }
                            else if (xpos == true)
                            {
                                guardartoken(no, fil, x - auxiliar.Length, "Posicion x", "U51", auxiliar, "No");
                                auxiliar = "";
                                x++;
                                no++;
                                xpos = false;
                                caso = 0;
                            }
                            else if (ypos == true)
                            {
                                guardartoken(no, fil, x - auxiliar.Length, "Posicion y", "U61", auxiliar, "No");
                                auxiliar = "";
                                x++;
                                no++;
                                ypos = false;
                                caso = 0;
                            }
                            else if (id == true)
                            {
                                guardartoken(no, fil, x - auxiliar.Length, "Nombre de Id", "AA3", auxiliar, "No");
                                auxiliar = "";
                                x++;
                                no++;
                                id = false;
                                caso = 0;
                            }




                        }

                        else if ((char.IsLetterOrDigit(a))|| (char.IsSymbol(a)) || (a=='.') || (a=='/') || (a == '_') || (a == '-') || (a == ':') || (a == '\\'))
                        {
                           
                            auxiliar = auxiliar + b;
                            x++;
                            caso = 17;

                        }
                        else
                        {
                            guardarerror(noe, fil, x, a + "", "Caracter desconocido");
                            noe++;
                            x = entrada.Length;
                        }


                        break;

                       

                    //Cerrar etiquetas

                    case 18:
                        if (a == '#')
                        {
                            x++;
                            caso = 0;
                        }
                        else if (char.IsLetterOrDigit(a) || (a=='-')||(a=='_') || (a == '=') || (a == '+') || (a == '-') || (a == '*') || (a == '/') )
                        {
                            auxiliar = auxiliar + a;
                            x++;
                            caso = 18;

                        }
                        else if (a == ';')
                        {
                            auxiliar = auxiliar + a;
                            guardartoken(no, fil, x - auxiliar.Length, "Acciones y Operadores", "CO3", auxiliar, "No");
                            no++;
                            auxiliar = "";
                            x++;
                            caso = 18;
                        }
                        else if (a == '<')
                        {

                            x++;
                            caso = 19;
                        }
                        else if (a == '(')
                        {
                           
                           
                            caso = 22;
                        }
                        else
                        {
                            guardarerror(noe, fil, x, a + "", "Caracter desconocido");
                            noe++;
                            x = entrada.Length;
                        }

                        break;
                        

                    case 19:
                        if (a == '%')
                        {
                            x++;
                            caso = 20;

                        }
                        else if (char.IsLetter(a))
                        {
                            caso = 1;

                        }
                        else
                        {
                            guardarerror(noe, fil, x, a + "", "Caracter desconocido");
                            noe++;
                            x = entrada.Length;
                        }

                        break;
                    case 20:
                        if (char.IsLetter(a))
                        {
                            cerradura = cerradura + a;
                            x++;
                            caso = 20;

                        }
                        else if (a == '>')
                        {
                            caso = 21;

                        }
                        else
                        {
                            guardarerror(noe, fil, x, a + "", "Caracter desconocido");
                            noe++;
                            x = entrada.Length;
                        }
                        break;


                    case 21:
                        if (cerradura.Equals("var"))
                        {
                            char bb = auxiliar[0];

                            if (char.IsLetter(bb))
                            {

                                guardartoken(no, fil, x - (auxiliar.Length + 5), "Nombre Variable", "V5", auxiliar, "No");
                                no++;
                                auxiliar = "";
                            }
                            else
                            {
                                guardarerror(noe, fil, x, auxiliar, "Nombre de variable invalido");
                                noe++;
                                auxiliar = "";
                              
                            }

                            guardartoken(no, fil, x - 3, "Etiqueta de cierre: Variable", "V6", "<%var>", "Si");
                            no++;
                            cerradura = "";
                            caso = 0;

                        }
                        else if (cerradura.Equals("jugador"))
                        {
                           

                            guardartoken(no, fil, x - 7, "Etiqueta de cierre: Jugador","J4", "<%jugador>", "Si");
                            no++;
                            cerradura = "";
                            caso = 0;

                        }
                        else if (cerradura.Equals("campo"))
                        {


                            guardartoken(no, fil, x - 5, "Etiqueta de cierre: Campo", "C5", "<%campo>", "Si");
                            no++;
                            cerradura = "";
                            caso = 0;

                        }
                        
                        else if (cerradura.Equals("vidas"))
                        {
                            guardartoken(no, fil, x - (auxiliar.Length +7), "Valor de vidas", "J111", auxiliar, "No");
                            no++;
                            auxiliar = "";

                            guardartoken(no, fil, x - 5, "Etiqueta de cierre: Vidas", "J112", "<%vidas>", "Si");
                            no++;
                            cerradura = "";
                            caso = 0;

                        }
                        else if (cerradura.Equals("poder"))
                        {
                            guardartoken(no, fil, x - (auxiliar.Length + 7), "Valor de poder", "J121", auxiliar, "No");
                            no++;
                            auxiliar = "";

                            guardartoken(no, fil, x - 5, "Etiqueta de cierre: Poder", "J122", "<%poder>", "Si");
                            no++;
                            cerradura = "";
                            caso = 0;

                        }
                        else if (cerradura.Equals("remoto"))
                        {
                            guardartoken(no, fil, x - (auxiliar.Length + 8), "Valor de remoto", "J131", auxiliar, "No");
                            no++;
                            auxiliar = "";

                            guardartoken(no, fil, x - 6, "Etiqueta de cierre: Remoto", "J132", "<%remoto>", "Si");
                            no++;
                            cerradura = "";
                            caso = 0;

                        }
                        else if (cerradura.Equals("fantasma"))
                        {
                            guardartoken(no, fil, x - (auxiliar.Length + 11), "Valor de fantasma", "J141", auxiliar, "No");
                            no++;
                            auxiliar = "";

                            guardartoken(no, fil, x - 8, "Etiqueta de cierre: Fantasma", "J142", "<%fantasma>", "Si");
                            no++;
                            cerradura = "";
                            caso = 0;

                        }
                        else if (cerradura.Equals("x"))
                        {
                            guardartoken(no, fil, x - (auxiliar.Length + 3), "Valor de x", "X11", auxiliar, "No");
                            no++;
                            auxiliar = "";

                            guardartoken(no, fil, x - 1, "Etiqueta de cierre: x", "X2", "<%x>", "Si");
                            no++;
                            cerradura = "";
                            caso = 0;

                        }
                        else if (cerradura.Equals("y"))
                        {
                            guardartoken(no, fil, x - (auxiliar.Length + 3), "Valor de y", "Y11", auxiliar, "No");
                            no++;
                            auxiliar = "";

                            guardartoken(no, fil, x - 1, "Etiqueta de cierre: Y", "Y2", "<%y>", "Si");
                            no++;
                            cerradura = "";
                            caso = 0;

                        }
                        else if (cerradura.Equals("roca"))
                        {


                            guardartoken(no, fil, x - 4, "Etiqueta de cierre: Roca", "RR3", "<%roca>", "Si");
                            no++;
                            cerradura = "";
                            caso = 0;

                        }
                        else if (cerradura.Equals("rocas"))
                        {


                            guardartoken(no, fil, x - 5, "Etiqueta de cierre: Rocas", "R2", "<%rocas>", "Si");
                            no++;
                            cerradura = "";
                            caso = 0;

                        }
                        else if (cerradura.Equals("llave"))
                        {


                            guardartoken(no, fil, x - 5, "Etiqueta de cierre: Llave", "CTL2", "<%llave>", "Si");
                            no++;
                            cerradura = "";
                            caso = 0;

                        }
                        else if (cerradura.Equals("bono"))
                        {


                            guardartoken(no, fil, x - 4, "Etiqueta de cierre: Bono", "CTB2", "<%bono>", "Si");
                            no++;
                            cerradura = "";
                            caso = 0;

                        }
                        else if (cerradura.Equals("salida"))
                        {


                            guardartoken(no, fil, x - 6, "Etiqueta de cierre: Salida", "CTS2", "<%salida>", "Si");
                            no++;
                            cerradura = "";
                            caso = 0;

                        }
                        else if (cerradura.Equals("tesoros"))
                        {


                            guardartoken(no, fil, x - 7, "Etiqueta de cierre: Tesoro", "T2", "<%tesoro>", "Si");
                            no++;
                            cerradura = "";
                            caso = 0;

                        }
                        else if (cerradura.Equals("movimiento"))
                        {
                            guardartoken(no, fil, x - (auxiliar.Length + 12), "Valor de movimiento", "EEMM2", auxiliar, "No");
                            no++;
                            auxiliar = "";

                            guardartoken(no, fil, x - 10, "Etiqueta de cierre: Movimiento", "EEMM3", "<%movimiento>", "Si");
                            no++;
                            cerradura = "";
                            caso = 0;

                        }
                        else if (cerradura.Equals("movimientos"))
                        {


                            guardartoken(no, fil, x - 11, "Etiqueta de cierre: Movimientos", "EEM2", "<%movimientos>", "Si");
                            no++;
                            cerradura = "";
                            caso = 0;

                        }
                        else if (cerradura.Equals("enemigo"))
                        {


                            guardartoken(no, fil, x - 7, "Etiqueta de cierre: Enemigo", "EE2", "<%enemigo>", "Si");
                            no++;
                            cerradura = "";
                            caso = 0;

                        }
                        else if (cerradura.Equals("enemigos"))
                        {


                            guardartoken(no, fil, x - 8, "Etiqueta de cierre: Enemigos", "E2", "<%enemigos>", "Si");
                            no++;
                            cerradura = "";
                            caso = 0;

                        }
                        else if (cerradura.Equals("accion"))
                        {
                            if (auxiliar.Equals(""))
                            {
                                guardartoken(no, fil, x - 6, "Etiqueta de cierre: Accion", "AA4", "<%accion>", "Si");
                                no++;
                                cerradura = "";
                                caso = 0;
                            }
                            else
                            {
                                guardartoken(no, fil, x - auxiliar.Length, "Acciones y Operadores", "CO3", auxiliar, "No");
                                no++;
                                auxiliar = "";




                                guardartoken(no, fil, x - 6, "Etiqueta de cierre: Accion", "AA4", "<%accion>", "Si");
                                no++;
                                cerradura = "";
                                caso = 0;
                            }

                        }
                        else if (cerradura.Equals("acciones"))
                        {


                            guardartoken(no, fil, x - 8, "Etiqueta de cierre: Acciones", "A2", "<%acciones>", "Si");
                            no++;
                            cerradura = "";
                            caso = 0;

                        }
                        else if (cerradura.Equals("variables"))
                        {


                            guardartoken(no, fil, x - 10, "Etiqueta de cierre: Variables", "V22", "<%variables>", "Si");
                            no++;
                            cerradura = "";
                            caso = 0;

                        }
                        else
                        {
                            guardarerror(noe, fil, x, cerradura, "Etiqueta de Cierre desconocida");
                            noe++;
                            x = entrada.Length;
                        }
                        break;



                        //Condiciones
                       
                    case 22:
                        
                        if ((auxiliar.Equals("si")) || (auxiliar.Equals("ademassi"))  ) {
                            guardartoken(no, fil, x - auxiliar.Length, "Identificador de Condicion", "CO1", auxiliar, "Si");
                           
                            no++;
                            auxiliar = "";
                           
                          
                           
                            caso = 0;
                        }
                        else if ((auxiliar.Equals("sino")))
                            {
                            guardartoken(no, fil, x - auxiliar.Length, "Identificador de Condicion", "CO1", auxiliar, "Si");
                            
                            no++;
                            auxiliar = "";
                            
                           caso = 0;
                        }
                        else
                        {
                            guardarerror(noe, fil, x, auxiliar, "Identificador de condicion desconocido");
                            noe++;
                            x = entrada.Length;
                        }
                        break;
                    case 23:
                       
                        if (char.IsLetterOrDigit(a))
                        {
                            
                            auxiliar = auxiliar + a;
                            x++;
                            caso = 23;
                        }
                        else if ((a == '<') || (a == '>') || (a == '=') || (a == '(') || (a == ')'))
                        {
                            operador1 = operador1 + a;

                            condicion =condicion+'('+ auxiliar + a;
                            auxiliar = "";
                            x++;
                            caso = 24;
                        }
                        else
                        {
                            guardarerror(noe, fil, x, a + "", "Caracter desconocido");
                            noe++;
                            x = entrada.Length;
                        }

                        break;
                    case 24:
                       
                        if ((a == '<') || (a == '>') || (a == '=') )
                        {
                            operador2 =  operador1+ a;
                            
                            
                            condicion = condicion +a;
                            x++;
                            caso = 25;
                        }
                        else if (char.IsLetterOrDigit(a))
                        {
                            
                            caso = 25;
                        }
                        else
                        {
                            guardarerror(noe, fil, x, a + "", "Caracter desconocido");
                            noe++;
                            x = entrada.Length;
                        }


                        break;
                    case 25:

                         if (char.IsLetterOrDigit(a))
                        {
                           
                            auxiliar = auxiliar+a;
                            x++;
                            caso = 25;
                        }
                         else if (a == ')')
                        {
                            condicion = condicion + auxiliar + a;
                            auxiliar = "";
                            x++;
                            caso = 0;
                        }
                        else
                        {
                            guardarerror(noe, fil, x, a + "", "Caracter desconocido");
                            noe++;
                            x = entrada.Length;
                        }

                        break;
                    case 26:
                             if (a == '{')
                        {
                            guardartoken(no, fil, x - condicion.Length, "Condicion", "CO2", condicion, "No");
                            condicion = "";
                            no++;
                            auxiliar = "";
                            guardartoken(no, fil, x , "Corchete Abierto", "U10", "{", "Si");
                            no++;
                            x++;
                            caso = 27;
                        }
                             else if ((a == 'y') || (a == 'o'))
                        {
                            condicion = condicion + a;
                            x++;
                            x++;
                            caso = 0;

                        }

                        else
                        {
                            guardarerror(noe, fil, x, a + "", "Caracter desconocido");
                            noe++;
                            x = entrada.Length;
                        }
                        break;
                    case 27:
                        if (char.IsLetterOrDigit(a))
                        {

                            auxiliar = auxiliar + a;
                            x++;
                            caso = 27;
                        }
                        else if ((a == '+') || (a == '-')  || (a == '='))
                        {
                           

                            condicion = auxiliar + " " + a;
                            auxiliar = "";
                            x++;
                            caso = 28;

                        }
                        else
                        {
                            guardarerror(noe, fil, x, a + "", "Caracter desconocido");
                            noe++;
                            x = entrada.Length;
                        }
                        break;
                    case 28:

                        if ((a == '='))
                        {
                          
                            condicion = condicion + a;
                            operador3 = "";
                            operador4 = "";
                            x++;
                            caso = 29;

                        }
                        else if (char.IsLetterOrDigit(a) )
                        {
                           
                            caso = 29;
                        }
                        else if (a == '(')
                        {
                            cad1 = auxiliar;
                            auxiliar = "";
                            operador4 = operador3;
                            
                            condicion = condicion + " " + '(';
                            x++;
                            caso = 29;


                        }
                        else if ((a == '+') || (a == '-') || (a == '*') || (a == '/') || (a == '(') || (a == ')'))
                        {
                            operador3 = operador3 + a;

                            condicion = condicion  + a;
                            auxiliar = "";
                            x++;
                            caso = 28;

                        }
                        else if (a == ';')
                        {
                           
                            condicion = condicion + ';';
                            guardartoken(no, fil, x - condicion.Length, "Acciones y Operadores", "CO3", condicion, "No");
                            condicion = "";
                            auxiliar="";
                            no++;
                            x++;
                            caso = 30;

                        }

                        else
                        {
                            guardarerror(noe, fil, x, a + "", "Caracter desconocido");
                            noe++;
                            x = entrada.Length;
                        }
                        break;
                    case 29:
                        if (char.IsLetterOrDigit(a))
                        {
                            auxiliar = auxiliar + a;
                            x++;
                            caso = 29;
                        }
                        else if (a == ';')
                        {
                           
                            condicion = condicion + auxiliar+ ';';
                            guardartoken(no, fil, x-condicion.Length, "Acciones y Operadores", "CO3", condicion, "No");
                            condicion = "";
                            auxiliar = "";
                            no++;
                            x++;
                            caso = 30;

                        }
                        else if ((a == '+') || (a == '-') || (a == '*') || (a == '/') || (a == '(') || (a == ')'))
                        {
                            operador3 = operador3 + a;

                            condicion = condicion +auxiliar + a;
                            auxiliar = "";
                            x++;
                            caso = 28;

                        }
                        else
                        {
                            guardarerror(noe, fil, x, a + "", "Caracter desconocido");
                            noe++;
                            x = entrada.Length;
                        }

                        break;
                    case 30:
                        if (char.IsLetter(a))
                        {
                            caso = 27;

                        }
                       else if (a == '}')
                        {
                           
                            guardartoken(no, fil, x , "Corchete Cerradoro", "U11", "}", "Si");
                            x++;
                            no++;
                            caso = 0;

                        }
                        else
                        {
                            guardarerror(noe, fil, x, a + "", "Caracter desconocido");
                            noe++;
                            x = entrada.Length;
                        }

                        break;
                }
            }
        }


        public void guardartoken(int num, int fil, int col, string nombre, string id, string valor,string palabra)
        {

            Tokens nuevo = new Tokens(num, fil, col, nombre, id, valor, palabra);


            Token.Insertar(nuevo);





        }
        public void guardarerror(int num, int fil, int col, string caracter, string descripcion)
        {

            Error nuevo = new Error(num, fil, col, caracter, descripcion );


            tokenerror.Insertar(nuevo);





        }


        public string direccion = "";
        public int fil = 0;
        public int no = 0;
        public int noe = 0;
        Cola Token = new Cola();
        Colaerror tokenerror = new Colaerror();
        private void button2_Click(object sender, EventArgs e)
        {
            
          
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
           
        }
        public void inicio()
        {
            Token.eliminar();
            tokenerror.eliminar();
            fil = 0;
            no = 0;
            noe = 0;


            leerarchivo(direccion);
            Token.mostrar();
            tokenerror.mostrar();
            map1 = map;
            map++;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            inicio();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
        public string name = "";
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Enabled = true;
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try { 
                
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {

                            direccion = openFileDialog1.FileName;
                        
                            copiararchivo(direccion);
                            name = openFileDialog1.FileName;


                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: no se puede leer el archivo" + ex.Message);
                }
            }
        }
        public int map = 1;
        public void guardarcomo()
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog1.Title = "Guardar Archivo como";
           
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
              
                string dir = saveFileDialog1.FileName;

                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
                fs.Close();
                direccion = dir;

                using (var fileStream = File.Create(dir))
                {
                    var texto = new UTF8Encoding(true).GetBytes(richTextBox1.Text);
                    fileStream.Write(texto, 0, texto.Length);
                    fileStream.Flush();

                }



            }



        }
        public int map1 = 0;
        private void tokensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Process.Start(@"C:\Users\equipo\Desktop\Bomberman\Tablas\SIMBOLOS_" + map1 + ".html");
           
        }

        private void erroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            Process.Start(@"C:\Users\equipo\Desktop\Bomberman\Tablas\ERRORES_" + map1 + ".html");
        
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guardarcomo();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var archivo = direccion;




            // eliminar el fichero si ya existe
            if (File.Exists(archivo))

            {

                File.Delete(archivo);

                // crear el fichero
                using (var fileStream = File.Create(archivo))
                {
                    var texto = new UTF8Encoding(true).GetBytes(richTextBox1.Text);
                    fileStream.Write(texto, 0, texto.Length);
                    fileStream.Flush();

                }

            }

            else
            {
                guardarcomo();

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            


            label1.Text = name;
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Enabled = true;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 acercade = new Form2();
            acercade.StartPosition = FormStartPosition.CenterScreen;
            acercade.Show();
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Token.analizador();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\equipo\Desktop\Bomberman\Tablas\Sintactico.html");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
           
           
        }

       
        

        private void button2_Click_1(object sender, EventArgs e)
        {


            grafic = new Form3();
            vidas = Token.vidas();
            dibujar();

          
        }

        private void button1_Leave(object sender, EventArgs e)
        {

        }

        private void button2_Leave(object sender, EventArgs e)
        {
            
        }
        public int vidas = 0;
     
        private void timer1_Tick(object sender, EventArgs e)
        {

            
            

                timer1.Interval = 1000;

                if (grafic.termino == true)
                {
                    vidas--;

                    grafic.Close();

                    grafic = new Form3();

                if (vidas == 0)
                {
                    grafic.Close();
                    grafic = new Form3();
                    MessageBox.Show("Ha perdido");
                    timer1.Enabled = false;
                }
                else
                {

                    dibujar();

                    dibujar();
                }
                }

            
           
            /*if (grafic.estallo == true)
            {
                grafic.estallo = false;

                dibujar();

            }*/
        }
    }
}
