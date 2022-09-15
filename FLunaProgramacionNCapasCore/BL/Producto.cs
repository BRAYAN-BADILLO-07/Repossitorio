using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static ML.Result Add(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FLunaProgramacionNCapasContext context = new DL.FLunaProgramacionNCapasContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"ProductoAdd '{producto.Nombre}','{producto.PrecioUnitario}',{producto.Stock}, {producto.Descripcion}");
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo agregar el registro";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Producto producto)
        {
            ML.Result result =  new ML.Result();
            try
            {
                using(DL.FLunaProgramacionNCapasContext context = new DL.FLunaProgramacionNCapasContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"ProductoUpdate {producto.IdProducto}, '{producto.Nombre}','{producto.PrecioUnitario}',{producto.Stock},'{producto.Descripcion}', {producto.Proveedor.IdProveedor}, {producto.Departamento.IdDepartamento}");
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un problema";

                    }
                    result.Correct=true;
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage=ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FLunaProgramacionNCapasContext context = new DL.FLunaProgramacionNCapasContext())
                {
                    var query = context.Productos.FromSqlRaw($"ProductoGetAll").AsEnumerable().ToList();
                    result.Objects = new List<object>();
                    if(query !=null)
                    {
                        foreach(var obj in query)
                        {
                            //producto
                            ML.Producto producto = new ML.Producto();
                            producto.IdProducto = obj.IdProducto;
                            producto.Nombre = obj.Nombre;
                            producto.PrecioUnitario = (int)obj.PrecioUnitario;
                            producto.Stock = obj.Stock;

                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProveedor = obj.IdProveedor.Value;

                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = obj.IdDepartamento.Value;

                            producto.Descripcion = obj.Descripcion.ToString();

                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
