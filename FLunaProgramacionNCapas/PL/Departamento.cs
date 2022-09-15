using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Departamento
    {
        public static void Add()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Ingrese el Nombre: ");
            departamento.Nombre = Console.ReadLine();

            departamento.Area = new ML.Area();
            Console.WriteLine("Ingresa el IdArea: ");

            departamento.Area.IdArea = int.Parse(Console.ReadLine());

            ML.Result result = BL.Departamento.Add(departamento);

            if (result.Correct)
            {
                Console.WriteLine("Registro exitoso");
            }
            else
            {
                Console.WriteLine("Ocurrio un problema");
            }
        }
        public static void Update()
        {
            ML.Departamento departamento = new ML.Departamento();
            Console.WriteLine("Ingrese el IdDepartamento: ");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el Nombre: ");
            departamento.Nombre = Console.ReadLine();

            departamento.Area = new ML.Area();
            Console.WriteLine("Ingrese el IdArea: ");
            departamento.Area.IdArea = int.Parse(Console.ReadLine());

            ML.Result result = BL.Departamento.Update(departamento);

            if (result.Correct)
            {
                Console.WriteLine("Registro exitoso");
            }
            else
            {
                Console.WriteLine("Ocurrio un problema");
            }
        }
        public static void Detele()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Ingrese el IdDepartamento");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            ML.Result result = BL.Departamento.Delete(departamento);

            if (result.Correct)
            {
                Console.WriteLine("Registro eliminado exitosamente");
                departamento.IdDepartamento = int.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Ocurrio un problema al eliminar el registro");
            }
        }
        public static void GetAll()
        {
            ML.Result result = BL.Departamento.GetAll();
            if(result.Correct)
            {
                foreach(ML.Departamento departamento in result.Objects)
                {
                    Console.WriteLine("IdDepartamento: " + departamento.IdDepartamento);
                    Console.WriteLine("Nombre: " + departamento.Nombre);
                    Console.WriteLine("IdArea: " + departamento.Area.IdArea);
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Ocurrio un problema al realizar la operacion");
            }
        }

        public static void GetById()
        {
            Console.WriteLine("Ingrese el Id a consultar: ");
            ML.Result result = BL.Departamento.GetById(int.Parse(Console.ReadLine()));

            if(result.Correct)
            {
                ML.Departamento departamento = ((ML.Departamento)result.Object);
                Console.WriteLine("IdDepartamento: " + departamento.IdDepartamento);
                Console.WriteLine("Nombre: " + departamento.Nombre);
                Console.WriteLine("IdArea: "+departamento.Area.IdArea);

                Console.WriteLine("------------------------------");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Hay un problema al mostrar el resgistro");
            }
        }
    }   
}