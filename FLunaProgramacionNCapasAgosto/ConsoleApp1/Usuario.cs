using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Usuario
    {
        public static void add()
        {
            ML.Alumno alumno = new ML.alumno();

            Console.WriteLine("Ingrese el nombre");
            alumno.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el Apellido Paterno");
            alumno.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el Apellido Materno");
            alumno.ApellidoMaterno = Console.ReadLine();
        }
    }
}
