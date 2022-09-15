using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double v1, v2, res;
            int opt;

            do
            {
                Console.Clear();
                Console.WriteLine("Calculadora");
                Console.WriteLine("Selecciona alguna opcion");
                Console.WriteLine("1. Sumar");
                Console.WriteLine("2. Restar");
                Console.WriteLine("3. Dividir");
                Console.WriteLine("4. Multiplicar");
                Console.WriteLine("5. Salir");
                opt = int.Parse(Console.ReadLine());

                switch (opt)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Opcion Sumar");
                        Console.WriteLine("Coloque el primer numero");
                        v1 = Convert.ToDouble( Console.ReadLine());
                        Console.WriteLine("Coloque el segundo numero");
                        v2 = Convert.ToDouble( Console.ReadLine());
                        res = v1 + v2;
                        Console.WriteLine("El resultado es : " + (res));
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Opcion Restar");
                        Console.WriteLine("Coloque el primer numero");
                        v1 = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Coloque el segundo numero");
                        v2 = Convert.ToDouble(Console.ReadLine());
                        res = v1 - v2;
                        Console.WriteLine("El resultado es : " + (res));
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Opcion Dividir");
                        Console.WriteLine("Coloque el primer numero");
                        v1 = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Coloque el segundo numero");
                        v2 = Convert.ToDouble(Console.ReadLine());
                        res = v1 / v2;
                        Console.WriteLine("El resultado es : " + (res));
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Opcion Multiplicar");
                        Console.WriteLine("Coloque el primer numero");
                        v1 = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Coloque el segundo numero");
                        v2 = Convert.ToDouble(Console.ReadLine());
                        res = v1 * v2;
                        Console.WriteLine("El resultado es : " + (res));
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("Adios");
                        break;

                    default:
                        Console.WriteLine("Opcion Invalida");
                        break;

                }
             Console.ReadLine();

            } while ((opt > 0) && (opt <= 4));

        }
    }
}
