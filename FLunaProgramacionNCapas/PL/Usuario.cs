using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {
        public static void AddSP()
        {
           ML.Usuario usuario = new ML.Usuario();//Instacia 
            
            
            Console.WriteLine("Ingrese el Nombre ");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el ApellidoPaterno ");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el ApellidoMaterno ");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el sexo ");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Ingresa tu Email ");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Ingresa tu Curp ");
            usuario.Curp = Console.ReadLine();

            Console.WriteLine("Ingresa tu Fecha de Nacimiento ");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Ingresa el numero de Telefono ");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Ingresa tu Celular ");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Ingresa tu contrasenia ");
            usuario.Constrasenia = Console.ReadLine();

            Console.WriteLine("Ingrese el User name ");
            usuario.UserName = Console.ReadLine();

            usuario.Rol = new ML.Rol();//instancia de la llave foranea

            Console.WriteLine("Ingresa el IdRol"); 
            usuario.Rol.IdRol=int.Parse(Console.ReadLine());

          
            //ML.Result result = BL.Usuario.AddsP(usuario);//
            ML.Result result = BL.Usuario.AddLinq(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Registro Exitoso");
            }
            else
            {
                Console.WriteLine("Ocurrio un error al insertar el registro");
            }
        }

        public static void UpdatesP()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingresa el Id del USuario: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el Nombre: ");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el Apellido Paterno: ");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingresa el Apellido Materno: ");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingresa el Sexo: ");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Ingresa el Email: ");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Introcude la Fecha de Nacimiento ");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Ingresa el numero de Telefono: ");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Ingresa tu Celular: ");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Ingresa tu CURP: ");
            usuario.Curp = Console.ReadLine();

            Console.WriteLine("Ingresa tu UserName: ");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingresa tu contrasenia: ");
            usuario.Constrasenia = Console.ReadLine();

            usuario.Rol = new ML.Rol();//instancia de la llave foranea

            Console.WriteLine("Ingresa el IdRol: ");
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

            // ML.Result result = BL.Usuario.UpdateEF(usuario);
            ML.Result result = BL.Usuario.UpdateLinq(usuario);
           

            if (result.Correct)
            {
                Console.WriteLine("El registro se realizo exitosamente");
            }
            else
            {
                Console.WriteLine("Ocurrio un error al actualizar");
            }
        }

        public static void DeleteSP()
        {
            ML.Usuario usuario = new ML.Usuario();
            

            Console.WriteLine("Ingresa el IdUsuario");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            // ML.Result result = BL.Usuario.DeleteEF(usuario);
            ML.Result result = BL.Usuario.DeleteLinq(usuario);

            if (result.Correct)
            {
                Console.WriteLine("El registro se realizo exitosamente");
            }
            else
            {
                Console.WriteLine("Ocurrio un error al actualizar");
            }

        }
        public static void GetAllEF()
        {
            //ML.Result result = BL.Usuario.GetAll();
            //ML.Result result = BL.Usuario.GetAllEF();
            ML.Result result = BL.Usuario.GetAllLinq();
            if(result.Correct)
            {
                foreach(ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("IdUsuario: "+usuario.IdUsuario);
                    Console.WriteLine("Nombre: "+usuario.Nombre);
                    Console.WriteLine("ApellidoPaterno: "+usuario.ApellidoPaterno);
                    Console.WriteLine("ApellidoMaterno: " + usuario.ApellidoMaterno);
                    Console.WriteLine("Sexo: "+usuario.Sexo);
                    Console.WriteLine("Email: "+usuario.Email);
                    Console.WriteLine("FechaDeNacimiento: " + usuario.FechaNacimiento);
                    Console.WriteLine("Telefono: "+usuario.Telefono);
                    Console.WriteLine("Celular: "+usuario.Celular);
                    Console.WriteLine("Curp: "+usuario.Curp);
                    Console.WriteLine("UserName: "+usuario.UserName);
                    Console.WriteLine("Contrasenia: " + usuario.Constrasenia);
                    Console.WriteLine("IdRol: "+ usuario.Rol.IdRol);
                    Console.WriteLine("-----------------------");
                    Console.WriteLine();

                }
            }
            else 
            {
                Console.WriteLine("Ocurrio un error al realizar la consulta");
            }
        }
        public static void GetByIEf()
        {
            Console.WriteLine("Ingrese el Id a consultar");
            //ML.Result result=BL.Usuario.GetById(int.Parse(Console.ReadLine()));
            //ML.Result result = BL.Usuario.GetByIdEF(int.Parse(Console.ReadLine()));
            ML.Result result = BL.Usuario.GeyByIdLinq(int.Parse(Console.ReadLine()));

            
            if(result.Correct)
            {
                ML.Usuario usuario = ((ML.Usuario)result.Object);//Hace el UNBOXXING: PROCESO DE CONVERTIR UN TIPO DE OBJETO A TIPO DE DATO//
                Console.WriteLine("IdUsuario: " + usuario.IdUsuario);
                Console.WriteLine("Nombre: " + usuario.Nombre);
                Console.WriteLine("ApellidoPaterno: " + usuario.ApellidoPaterno);
                Console.WriteLine("ApellidoMaterno: " + usuario.ApellidoMaterno);
                Console.WriteLine("Sexo: " + usuario.Sexo);
                Console.WriteLine("Email: " + usuario.Email);
                Console.WriteLine("FechaDeNacimiento: " + usuario.FechaNacimiento);
                Console.WriteLine("Telefono: " + usuario.Telefono);
                Console.WriteLine("Celular: " + usuario.Celular);
                Console.WriteLine("Curp: " + usuario.Curp);
                Console.WriteLine("UserName: " + usuario.UserName);
                Console.WriteLine("Contrasenia: " + usuario.Constrasenia);
                Console.WriteLine("IdRol: "+ usuario.Rol.IdRol);
                
                Console.WriteLine("-----------------------");
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("Ocurrio un error al realizar la consulta");
            }

        }
       
    }
}
