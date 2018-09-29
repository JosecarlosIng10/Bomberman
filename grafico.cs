using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomberman
{
    class grafico
    {
        public static void GraficarCuadro(Form forma, Color color, int x, int y, int ancho)
        {


          

            Button i = new Button();
            i.Location = new Point(x,y);
            i.Width = 30;
            i.Height = 30;
            i.Enabled = false;

            forma.Controls.Add(i);
            

          
           
            
        }
        public static void bomba(Form forma, Color color, int x, int y, Bitmap bomb)
        {




            SolidBrush solidBrush = new SolidBrush(color);
            Graphics g = forma.CreateGraphics();
            g.FillRectangle(solidBrush, x, y, 30, 30);
            bomb.SetResolution(x, y);
            g.DrawImage(bomb, x, y, 30, 30);

            Button i = new Button();
            i.Location = new Point(x, y);
            i.Width = 30;
            i.Height = 30;
            i.Enabled = false;
            i.Text = "b";
            i.Visible = false;

            forma.Controls.Add(i);





        }
        public static void roca(Form forma, Bitmap txcolor,Color color, int x, int y)
        {
         




            Button i = new Button();
            i.Location = new Point(x, y);
            i.Width = 30;
            i.Height = 30;
            i.Enabled = false;
            i.BackColor = color;
            i.BackgroundImage = txcolor;
            i.Text = ".";

            forma.Controls.Add(i);





        }
        public static void enemigo(Form forma, Bitmap txcolor, Color color, int x, int y)
        {
            SolidBrush solidBrush = new SolidBrush(color);
            Graphics g = forma.CreateGraphics();
            g.FillRectangle(solidBrush, x, y, 30, 30);
            txcolor.SetResolution(x, y);
            g.DrawImage(txcolor, x, y, 30, 30);




            Button i = new Button();
            i.Location = new Point(x, y);
            i.Width = 30;
            i.Height = 30;
            i.Enabled = false;
            i.BackColor = color;
            i.BackgroundImage = txcolor;
            i.Visible = false;
            i.Text = "E";

            forma.Controls.Add(i);





        }

        public static void tesoro(Form forma, Bitmap txcolor, Color color, int x, int y,Color colorroca,Bitmap roca)
        {

            SolidBrush solidBrush = new SolidBrush(color);
            Graphics g = forma.CreateGraphics();
            g.FillRectangle(solidBrush, x, y, 30, 30);
            txcolor.SetResolution(x, y);
            g.DrawImage(txcolor, x, y, 30, 30);




           
            Button i = new Button();
            i.Location = new Point(x, y);
            i.Width = 30;
            i.Height = 30;
            i.Enabled = false;
            i.BackColor = colorroca;
            i.BackgroundImage = roca;
            i.BringToFront();
            i.Text = "..";

            i.Visible = false;
          
           

            
           
           

            forma.Controls.Add(i);







        }

       
        public bool termino(Form forma, int x, int y)
        {
            int xb = 0;
            int yb = 0;
            bool exis = false;

            foreach (Control c in forma.Controls)
            {


                if (c is Button)
                {
                    xb = c.Location.X;
                    yb = c.Location.Y;




                    if ((x == xb) && (y == yb) && (c.Text != "b"))
                    {
                        if (c.Text.Equals("E"))
                        {
                            exis = true;


                        }

                       
                    }


                }
            }


            return exis;

        }



        public  bool existe(Form forma,int x, int y)
        {
            int xb = 0;
            int yb = 0;
            bool exis = false;

            foreach (Control c in forma.Controls)
            {
              

                if (c is Button)
                {
                    xb = c.Location.X;
                    yb = c.Location.Y;


                   

                    if ((x == xb) && (y == yb)  && (c.Text != "E") && (c.Text != ".."))
                    {
                      
                        
                        exis = true;
                    }


                }
            }


            return exis;

        }

       

        public bool existebomba(Form forma, int x, int y)
        {
            int xb = 0;
            int yb = 0;
            bool exis = false;

            foreach (Control c in forma.Controls)
            {


                if (c is Button)
                {
                    xb = c.Location.X;
                    yb = c.Location.Y;




                    if ((x == xb) && (y == yb)  )
                    {
                        if (c.Text == "b")
                        {
                            exis = true;
                        }

                       
                    }


                }
            }


            return exis;

        }

      


           

      



        public static void jugador(Form forma, Color color, int x, int y, int ancho, Bitmap a)
        {
            
           
           

            SolidBrush solidBrush = new SolidBrush(color);
            Graphics g = forma.CreateGraphics();
            g.FillRectangle(solidBrush, x, y, ancho, ancho);
            a.SetResolution(x, y);
            g.DrawImage(a, x, y, ancho, ancho);


        }
        public static void campo(Form forma, Color color, int x, int y, int ancho, Bitmap a)
        {


            SolidBrush solidBrush = new SolidBrush(color);
            Graphics g = forma.CreateGraphics();
            g.FillRectangle(solidBrush, x, y, ancho, ancho);
            //Rectangle destRectangle2 = new Rectangle(200, 40, 200, 160);
            a.SetResolution(x, y);
            g.DrawImage(a, x,y,ancho,ancho);

        }

    }
}

