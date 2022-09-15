using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrelgoOrdenado
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ordenando arreglo");
            int[] arregloNumero = new int[] { 11, 4, 15, 8, 0, 22, 3 };

            Array.Sort(arregloNumero);
            Console.WriteLine(string.Join(", ", arregloNumero));
        }
    }
}
