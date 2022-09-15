using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public  class Program
    {
        static void Main(string[] args)
        {
            int v1 = 0;
            int v2 = 1;

            Console.WriteLine("Ingresa un numero");
            Console.WriteLine(Console.ReadLine());

            for (int i = 0; i < 45; i++)
            {
                int temp = v1;
                v1 = v2;

                v2 = temp + v1;

                Console.WriteLine(v1);
            }    
        }
    }
}
