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
                using (DL_EF.FLunaProgramacionNCapasEntities context = new DL_EF.FLunaProgramacionNCapasEntities())
                {
                    var query = context.ProductoAdd(producto.Nombre, producto.PrecioUnitario, producto.Stock, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento, producto.Descripcion);
                    if(query>=1)
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
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.FLunaProgramacionNCapasEntities context = new DL_EF.FLunaProgramacionNCapasEntities())
                {
                    var query = context.ProductoUpdate(producto.IdProducto, producto.Nombre, producto.PrecioUnitario, producto.Stock, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento, producto.Descripcion);
                    if( query>=1)
                    { 
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo Actualizar el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct= false;
                result.ErrorMessage= ex.Message;
            }
            return result;
        }
        public static ML.Result Delete(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.FLunaProgramacionNCapasEntities context = new DL_EF.FLunaProgramacionNCapasEntities())
                {
                    var query = context.ProductoDelete(producto.IdProducto);
                    if (query>=1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar el Registro";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.FLunaProgramacionNCapasEntities context = new DL_EF.FLunaProgramacionNCapasEntities())
                {
                    var query = context.ProductoGetAll().ToList();
                    result.Objects = new List<object>();
                    if (query !=null)
                    {
                        foreach (var obj in query)
                        {
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
                        result.ErrorMessage = "Ocurrio un Error al consultar los registros";
                        
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage=ex.Message;
            }
            return result;
        }
        public static ML.Result GetById(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.FLunaProgramacionNCapasEntities context = new DL_EF.FLunaProgramacionNCapasEntities())
                {
                    var objquery = context.ProductoGetById(IdProducto).FirstOrDefault();
                    if (objquery != null)
                    {
                        ML.Producto producto = new ML.Producto();
                        producto.IdProducto = objquery.IdProducto;
                        producto.Nombre=objquery.Nombre;
                        producto.PrecioUnitario = (int)objquery.PrecioUnitario;
                        producto.Stock = objquery.Stock;
                        
                        producto.Proveedor = new ML.Proveedor();
                        producto.Proveedor.IdProveedor = objquery.IdProveedor.Value;
                        


                        producto.Departamento = new ML.Departamento();
                        producto.Departamento.IdDepartamento = objquery.IdDepartamento.Value;


                        producto.Descripcion = objquery.Descripcion.ToString();
                        result.Object = true;
                    }
                    else
                    {
                        result.Correct = false;
                        
                    }
                }
            }
           catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage= ex.Message;
            }
            return result;
        }
    }
}
