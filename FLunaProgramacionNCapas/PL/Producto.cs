using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Producto
    {
        public static void Add()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingresa el Nombre: ");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el PrecioUnitario: ");
            producto.PrecioUnitario = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el Stock: ");
            producto.Stock = int.Parse(Console.ReadLine());

            producto.Proveedor = new ML.Proveedor();
            Console.WriteLine("Ingresa el IdProveedor");
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            producto.Departamento = new ML.Departamento();
            Console.WriteLine("Ingresa el IdDepartamento: ");
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa la Descripcion: ");
            producto.Descripcion = Console.ReadLine();

            ML.Result result =  BL.Producto.Add(producto);

            if(result.Correct)
            {
                Console.WriteLine("Registro exitoso");
            }
            else
            {
                Console.WriteLine("Ocurrio un problema en el registro");
            }
        }
        public static void Update()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingresa el IdProducto: ");
            producto.IdProducto = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el Nombre: ");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el PrecioUnitario: ");
            producto.PrecioUnitario = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el Stock: ");
            producto.Stock = int.Parse(Console.ReadLine());

            producto.Proveedor = new ML.Proveedor();
            Console.WriteLine("Ingresa el IdProveedor");
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            producto.Departamento = new ML.Departamento();
            Console.WriteLine("Ingresa el IdDepartamento: ");
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa la Descripcion: ");
            producto.Descripcion = Console.ReadLine();

            ML.Result result = BL.Producto.Update(producto);

            if (result.Correct)
            {
                Console.WriteLine("Registro exitoso");
            }
            else
            {
                Console.WriteLine("Ocurrio un problema en el registro");
            }
        }
        public static void Delete()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingresa el IdProducto: ");
            producto.IdProducto = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.Delete(producto);

            if(result.Correct)
            {
                Console.WriteLine("Registro Eliminado Exitosamente");
                producto.IdProducto = int.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Ocurrio un problema al eliminar el registro");
            }
        }
        public static void GetAll()
        {
            ML.Result result = BL.Producto.GetAll();

            if(result.Correct)
            {
                foreach (ML.Producto producto in result.Objects)
                {
                    Console.WriteLine("IdProducto: "+ producto.IdProducto);
                    Console.WriteLine("Nombre: "+ producto.Nombre);
                    Console.WriteLine("PrecioUnitario"+producto.PrecioUnitario);
                    Console.WriteLine("Stock" + producto.Stock);
                    Console.WriteLine("IdProveedor: "+producto.Proveedor.IdProveedor);
                    Console.WriteLine("IdDepartamento"+producto.Departamento.IdDepartamento);
                    Console.WriteLine("Descripcion" + producto.Descripcion);
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Ocurrio un Error al consultar los registros");
            }
        }
        public static void GetById()
        {
            Console.WriteLine("Ingrese el Id a consultar");
            ML.Result result = BL.Producto.GetById(int.Parse(Console.ReadLine()));

            if(result.Correct)
            {
                ML.Producto producto = ((ML.Producto)result.Object);
                Console.WriteLine("IdProducto: " + producto.IdProducto);
                Console.WriteLine("Nombre: " + producto.Nombre);
                Console.WriteLine("PrecioUnitario: " +producto.PrecioUnitario);
                Console.WriteLine("Stock: " + producto.Stock);
                Console.WriteLine("IdProveedor: " + producto.Proveedor.IdProveedor);
                Console.WriteLine("IdDepartamento: " + producto.Departamento.IdDepartamento);
                Console.WriteLine("Descripcion: " + producto.Descripcion);

                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("Ocurrio un error al consultar");
            }
        }
    }   
}
    
        