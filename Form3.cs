using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomberman
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;

        }
        public int posicion;
        
       
        protected override void OnKeyDown(KeyEventArgs keyg)
        {
          
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
          

        }
        public String color = "";
        public String colorjugador = "";
        public String texturacampo = "";
        public string txtjugador = "";
        Cola Token = new Cola();
        public int x = 71;
        public int y = 91;
        int largo = 0;
        int ancho = 0;
        int vidas = 0;

        public bool termino = false;

        

        public void asignarvalores(int l, int a,string tcamp,string tjug,string col,string colorjugad, int vid)
        {
            largo = l-1;
            ancho = a-1;
            texturacampo = tcamp;
            txtjugador = tjug;
            color = col;
            colorjugador = colorjugad;
            vidas = vid;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void label1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void Form3_KeyPress(object sender, KeyPressEventArgs e)
        {

            grafico grafico = new grafico();

            int anchoCuadricula = 30;
           
            

            if ((largo % 2) == 0)
            {
                largo--;
            }
            if ((ancho % 2) == 0)
            {
                ancho--;
            }


            int abajo = 60 + (31 * (largo));
            int derecha = 40 + (31 * (ancho));

               
            Bitmap a = new Bitmap(@"" + txtjugador + "");
            Bitmap bomb = new Bitmap(@"C:\Users\equipo\Desktop\Bomberman\img\bomba.png");
            Bitmap camp = new Bitmap(@"" + texturacampo + "");

            if ((e.KeyChar == Convert.ToChar(Keys.W))&& (y != 91) &&(grafico.existe(this,x,y-31)==false))

            {
                if (grafico.existebomba(this, x, y) == false)
                {
                    grafico.campo(this, Color.FromName(color), x, y, anchoCuadricula, camp);
                }
                y = y - 31;
                grafico.jugador(this, Color.FromName(colorjugador), x, y, anchoCuadricula, a);

                if (grafico.termino(this,x,y) == true)
                {
                   
                    termino = true;
                    x = 71;
                    y = 91;
                }

            }

            else if ((e.KeyChar == Convert.ToChar(Keys.S))&& (y != abajo) && (grafico.existe(this, x, y+31) == false))
            {
                if(grafico.existebomba(this, x, y)==false){
                    grafico.campo(this, Color.FromName(color), x, y, anchoCuadricula, camp);
                }
               
                y = y + 31;
                grafico.jugador(this, Color.FromName(colorjugador), x, y, anchoCuadricula, a);
                if (grafico.termino(this, x, y) == true)
                {
                    termino = true;
                    x = 71;
                    y = 91;
                }

            }
            else if ((e.KeyChar == Convert.ToChar(Keys.D))&& (x != derecha) && (grafico.existe(this, x+31, y) == false))
            {
                if (grafico.existebomba(this, x, y) == false)
                {
                    grafico.campo(this, Color.FromName(color), x, y, anchoCuadricula, camp);
                }
                x = x + 31;
                grafico.jugador(this, Color.FromName(colorjugador), x, y, anchoCuadricula, a);
                if (grafico.termino(this, x, y) == true)
                {
                    termino = true;
                    x = 71;
                    y = 91;
                }

            }
            else if ((e.KeyChar == Convert.ToChar(Keys.A))&& (x != 71) && (grafico.existe(this, x-31, y) == false))
            {
                if (grafico.existebomba(this, x, y) == false)
                {
                    grafico.campo(this, Color.FromName(color), x, y, anchoCuadricula, camp);
                }
                x = x - 31;
                grafico.jugador(this, Color.FromName(colorjugador), x, y, anchoCuadricula, a);
                if (grafico.termino(this, x, y) == true)
                {
                    termino = true;
                    x = 71;
                    y = 91; 
                }

            }
            else if (e.KeyChar == Convert.ToChar(Keys.D5)){
                grafico.bomba(this, Color.FromName(color), x, y, bomb);

                timer1.Enabled = true;
            }

            int xbom = 0;
            int ybom = 0;
        }
       
        public bool estallo = false;

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
           /* textBox8.Text = e.KeyChar + "";
           
            int anchoCuadricula = 30;
            Bitmap a = new Bitmap(@"C:\Users\equipo\Documents\Visual Studio 2015\Projects\Bomberman\Bomberman\prueba.PNG");
            color = textBox3.Text;




            int largo = Convert.ToInt32(textBox1.Text) ;
            int ancho = Convert.ToInt32(textBox2.Text) ;


            if ((largo % 2) == 0)
            {
                largo--;
            }
            if ((ancho % 2) == 0)
            {
                ancho--;
            }
            

            int abajo = 40 + (31*(largo));
            int derecha = 40 + (31 * (ancho));



            if (textBox6.Text.Equals(""))
            {
                if ((e.KeyChar == Convert.ToChar(Keys.W)) && (y!=71))

                {
                    grafico.GraficarCuadro(this, Color.FromName(color), x, y, anchoCuadricula);
                    y = y - 31;
                    grafico.jugador(this, Color.FromName("green"), x, y, anchoCuadricula, a);

                }

                else if ((e.KeyChar == Convert.ToChar(Keys.S))&&(y!=abajo))
                {
                    grafico.GraficarCuadro(this, Color.FromName(color), x, y, anchoCuadricula);
                    y = y + 31;
                    grafico.jugador(this, Color.FromName("green"), x, y, anchoCuadricula, a);

                }
                else if ((e.KeyChar == Convert.ToChar(Keys.D))&&(x!=derecha))
                {
                    grafico.GraficarCuadro(this, Color.FromName(color), x, y, anchoCuadricula);
                    x = x + 31;
                    grafico.jugador(this, Color.FromName("green"), x, y, anchoCuadricula, a);

                }
                else if ((e.KeyChar == Convert.ToChar(Keys.A))&&(x!=71))
                {
                    grafico.GraficarCuadro(this, Color.FromName(color), x, y, anchoCuadricula);
                    x = x - 31;
                    grafico.jugador(this, Color.FromName("green"), x, y, anchoCuadricula, a);

                }
            }
            else
            {
                texturacampo = textBox6.Text;
                Bitmap camp = new Bitmap(@"" + texturacampo + "");

                if (e.KeyChar == Convert.ToChar(Keys.W))

                {
                    grafico.campo(this, Color.FromName(color), x, y, anchoCuadricula, camp);
                    y = y - 31;
                    grafico.jugador(this, Color.FromName("green"), x, y, anchoCuadricula, a);

                }

                else if (e.KeyChar == Convert.ToChar(Keys.S))
                {
                    grafico.campo(this, Color.FromName(color), x, y, anchoCuadricula, camp);
                    y = y + 31;
                    grafico.jugador(this, Color.FromName("green"), x, y, anchoCuadricula, a);

                }
                else if (e.KeyChar == Convert.ToChar(Keys.D))
                {
                    grafico.campo(this, Color.FromName(color), x, y, anchoCuadricula, camp);
                    x = x + 31;
                    grafico.jugador(this, Color.FromName("green"), x, y, anchoCuadricula, a);

                }
                else if (e.KeyChar == Convert.ToChar(Keys.A))
                {
                    grafico.campo(this, Color.FromName(color), x, y, anchoCuadricula, camp);
                    x = x - 31;
                    grafico.jugador(this, Color.FromName("green"), x, y, anchoCuadricula, a);

                }
            }
            */



            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        int seg = 0;
        int min = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (vidas == 0) { }

            else
            {

                timer1.Interval = 1000;
                seg++;
                label6.Text = seg.ToString();
                label4.Text = min.ToString();
                label2.Text = vidas.ToString();

                if (seg == 60)
                {
                    seg = 0;
                    min++;
                }

            }
            
        }
    }
}
