using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa3
{
    class Archivo
    {
        private float parejas = 0;
        private float xk;
        private float rxy;
        private float r2;
        private float b0;
        private float b1;
        private float yk;
        
        public Archivo()
        {
            parejas = 0;
            xk = 0;
            rxy = 0;
            r2 = 0;
            b0 = 0;
            b1 = 0;
            yk = 0;
        }

        public float Parejas
        {
            set { parejas = value; }
            get { return parejas; }
        }

        public float Xk
        {
            set { xk = value; }
            get { return xk; }
        }

        public float Rxy
        {
            set { rxy = value; }
            get { return rxy; }
        }

        public float R2
        {
            set { r2 = value; }
            get { return r2; }
        }

        public float B0
        {
            set { b0 = value; }
            get { return b0; }
        }

        public float B1
        {
            set { b1 = value; }
            get { return b1; }
        }

        public float Yk
        {
            set { yk = value; }
            get { return yk; }
        }

        public void toString()
        {
            Console.WriteLine("N = " + parejas + "\nxk = " + xk + "\nr = " + rxy + "\nr2 = " + "\nb0 = " + b0 + "\nb1 = " + b1 + "\nyk = " + yk);
        }






    }
}
