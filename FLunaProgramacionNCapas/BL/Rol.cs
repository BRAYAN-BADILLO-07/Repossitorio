using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.FLunaProgramacionNCapasEntities context = new DL_EF.FLunaProgramacionNCapasEntities())
                {
                    var query = context.RolGetAll().ToList();
                    result.Objects = new List<object>();// esta es la lista que retorna el metodo aqui se deben guardar
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Rol  rol = new ML.Rol();//haces el objeto 
                            rol.IdRol = obj.IdRol;
                            rol.Nombre = obj.Nombre;// le guardas los atributos 
                            result.Objects.Add(rol);//aqui estas guardando en la lista de arriba todos los roles que haya en la base de datos 
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
