using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static ML.Result GetByIdPais(int IdPais)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.FLunaProgramacionNCapasContext context = new DL.FLunaProgramacionNCapasContext())
                {
                    var objquery = context.Estados.FromSqlRaw($"EstadoGeyByIdPais {IdPais}").AsEnumerable().ToList();
                    result.Objects = new List<object>();
                    if(objquery != null)
                    {
                        foreach(var item in objquery)
                        {
                            ML.Estado estado = new ML.Estado();
                            estado.IdEstado = item.IdEstado;
                            estado.Nombre = item.Nombre;

                            estado.Pais = new ML.Pais();
                            estado.Pais.IdPais = item.IdPais.Value;

                            result.Objects.Add(estado);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo mostrar el registro";
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
