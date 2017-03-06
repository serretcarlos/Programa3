using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Programa3
{
    class Controlador
    {
        private Archivo archivo;
        private float sumXiYi;
        private float sumXi;
        private float sumYi;
        private float sumXi2;
        private float sumYi2;

        public Controlador()
        {
            sumXiYi = 0;
            sumXi = 0;
            sumYi = 0;
            sumXi2 = 0;
            sumYi2 = 0;
        }

        public void ProcesarArchivo(string nombreArchivo)
        {
            archivo = new Archivo();
            string[] pareja;
            StreamReader entrada = null;
            bool bAbierto = false;
            try
            {
                entrada = File.OpenText(nombreArchivo);
                bAbierto = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (bAbierto)
            {
                try
                {
                    string sLinea = entrada.ReadLine();
                    archivo.Xk = float.Parse(sLinea);
                    sLinea = entrada.ReadLine();
                    while (sLinea != null)
                    {
                        string[] arrParejas = sLinea.Split(',');
                        sumXi += float.Parse(arrParejas[0]);
                        sumYi += float.Parse(arrParejas[1]);
                        sumXiYi += (float.Parse(arrParejas[0]) * float.Parse(arrParejas[1]));
                        sumXi2 += (float)Math.Pow(float.Parse(arrParejas[0]), 2);
                        sumYi2 += (float)Math.Pow(float.Parse(arrParejas[1]), 2);
                        archivo.Parejas++;
                        CalcularRxy();
                        CalcularR2();
                        CalcularB1();
                        CalcularB0();
                        CalcularYk();
                        sLinea = entrada.ReadLine();
                    }
                } 
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            archivo.toString();

        }



        private float CalcularR2()
        {
            return archivo.Rxy * archivo.Rxy;
        }

        private float CalcularRxy()
        {
            float rxy = (archivo.Parejas * sumXiYi) - (sumXi * sumYi) / ((float)Math.Sqrt((archivo.Parejas * sumXi2 - (sumXi * sumXi))) * (archivo.Parejas * sumYi2 - (sumYi * sumYi)));
            return rxy;
        }

        private float CalcularB0()
        {
            return sumYi / archivo.Parejas - archivo.B1 * (sumXi / archivo.Parejas);
        }

        private float CalcularB1()
        {
            return (sumXiYi - (archivo.Parejas * (sumXi / archivo.Parejas) * (sumYi / archivo.Parejas))) /
                (sumXi2 - (archivo.Parejas * (sumXi/archivo.Parejas) * (sumYi/archivo.Parejas)));
        }

        private float CalcularYk()
        {
            return archivo.B0 + archivo.B1 * archivo.Xk;
        }

    }
}
