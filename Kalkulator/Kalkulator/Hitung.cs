using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator
{
    class Hitung
    {
        public double tambah(double a, double b)
        {
            return a + b;
        }
        public double kurang(double a, double b)
        {
            return a - b;
        }
        public double kali(double a, double b)
        {
            return a * b;
        }
        public double bagi(double a, double b)
        {
            return a / b;
        }
        public double pangkat(double a,double b)
        {
            return Math.Pow(a, b);
        }
        public double akar(double a)
        {
            return Math.Sqrt(a);
        }
        public double sin(double a)
        {
            return Math.Sin(a);
        }
        public double cos(double a)
        {
            return Math.Cos(a);
        }
    }
}
