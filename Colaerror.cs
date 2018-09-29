using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    class Colaerror
    {
        public Error cabeza;
        public Error Ultimo;
        public Error Auxiliar;



        public Colaerror()
        {
            cabeza = null;
            Ultimo = null;
            Auxiliar = null;





        }

        public void Insertar(Error nuevo)
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

            Error actual = cabeza;


            string auxiliar = "";
            while (actual != null)
            {


                string num = "<td>" + actual.num + "</td>";
                string fila = "<td>" + actual.fila + "</td>";
                string col = "<td>" + actual.columna + "</td>";
                string caracter = "<td>" + actual.caracter + "</td>";
                string descripcion = "<td>" + actual.descripcion + "</td>";




                auxiliar = auxiliar + "<tr>" + num + fila + col + caracter + descripcion + "</tr>";




                actual = actual.Siguiente;


            }

            var archivo = @"C:\Users\equipo\Desktop\Bomberman\Tablas\ERRORES_"+map+".html";
            map++;
           
            // eliminar el fichero si ya existe
            if (File.Exists(archivo))
                File.Delete(archivo);

            // crear el fichero
            using (var fileStream = File.Create(archivo))
            {
                DateTime localDate = DateTime.Now;
                var texto = new UTF8Encoding(true).GetBytes("<html><head><title>Lenguajes</title></head><body><h1>Jose Carlos Estrada Garcia</h1><h2>Carnet 201212644</h2><h3>" + localDate.ToString() + "</h3><table><tr align=" + "center" + " bottom=" + "middle" + "><table border=" + '1' + " cellpadding=" + '1' + " cellspacing=" + '1' + " ><table bordercolordark=" + "#999933" + " bordercolorlight=" + "#CCCC66" + " border=" + '8' + " cellpadding=" + '1' + " cellspacing=" + '1' + "><tr  bgcolor= " + "#00FFFF" + " ><td><strong>#</strong></td><td><strong>Fila</strong></td><td><strong>Columna</strong></td><td><strong>Caracter</strong></td><td><strong>Descripcion</strong></td></tr><tr>" + auxiliar + "</tr></table> </body></html>");
                fileStream.Write(texto, 0, texto.Length);
                fileStream.Flush();

            }


            auxiliar = "";

           

        }




    }
}
