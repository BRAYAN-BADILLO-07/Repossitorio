using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {
        public static ML.Result MunicipioGetByIdEstado(int IdEstado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.FLunaProgramacionNCapasEntities context = new DL_EF.FLunaProgramacionNCapasEntities())
                {
                    var objquery = context.MunicipioGetByIdEstado(IdEstado).ToList();
                    result.Objects = new List<object>();
                    if (objquery != null)
                    {
                        foreach (var item in objquery)
                        {
                            ML.Municipio municipio = new ML.Municipio();
                            municipio.IdMunicipio = item.IdMunicipio;
                            municipio.Nombre = item.Nombre;

                            municipio.Estado = new ML.Estado();
                            municipio.Estado.IdEstado = item.IdEstado.Value;

                            result.Objects.Add(municipio);
                        }
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Hubo un problema con el registo";
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
