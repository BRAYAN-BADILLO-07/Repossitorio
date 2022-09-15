using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorialInversa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variables//
            int n, r, ni;

            //Valor de entrada//
            Console.WriteLine("Escribir un numero de 5 cifras");
            n = int.Parse(Console.ReadLine());

            //Proceso//
            r = n % 10;
            n = n/ 10;
            ni = r * 10;

            r = n % 10;
            n = n /10;
            ni = (ni + r) * 10;

            r = n % 10;
            n = n / 10;
            ni = (ni + r) * 10;

            r = n % 10;
            n = n / 10;
            ni = (ni + r) * 10;

            ni = ni + n;

            //Salida//
            Console.WriteLine("Numero inverso: " + ni);
            Console.ReadKey();
        }

    }
}
