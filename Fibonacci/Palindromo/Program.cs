using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromo
{
    public class Program
    {
        static bool EsPalindromo(string s)
        {
           
            for (int IdxL = 0, IdxR = s.Length - 1; IdxL < IdxR; IdxL++, IdxR--)
            {
                if (s[IdxL] != s[IdxR])
                    return false;
            }

            return true;
        }

        public static void Main()
        {//aqui me quede
            string[] Pruebas = { "OSO" };

            foreach (string s in Pruebas)
            {
                if (EsPalindromo(s))
                    Console.WriteLine($"\"{s}\" es palíndromo");
                else
                    Console.WriteLine($"\"{s}\" no es palíndromo");
            }
        }
    }    
        
    
}
