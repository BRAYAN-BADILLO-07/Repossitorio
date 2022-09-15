using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
     public class Program
    {
        static void Main(String[] args)
        {
            String resp = " ";

            do
            {
                Console.WriteLine("Selecciona una opcion");
                Console.WriteLine("Agregar, Actualizar, Eliminar, GetAll, GetById");
                resp = Console.ReadLine();
                string elecion = Convert.ToString(resp);

                switch (elecion)
                {
                    case "Agregar":
                        PL.Departamento.Add();
                        break;
                    case "Actualizar":
                        PL.Departamento.Update();
                        break;
                    case "Eliminar":
                        PL.Departamento.Detele();
                        break;
                    case "GetAll":
                        PL.Departamento.GetAll();
                        break;
                    case "GetById":
                        PL.Departamento.GetById();
                        break;
                }
                Console.WriteLine("¿Desea realizar una nueva Operación? SI/NO");
                resp = Console.ReadLine();
            }
            while (resp == "SI" || resp == "NO");
        }
    }
}
