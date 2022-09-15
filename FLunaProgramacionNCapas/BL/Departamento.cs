using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
  public  class Departamento
  {
        public static ML.Result Add(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.FLunaProgramacionNCapasEntities context = new DL_EF.FLunaProgramacionNCapasEntities())
                {
                    var query = context.DepartamentoAdd(departamento.Nombre);
                    if (query>=1)
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
                result.ErrorMessage=ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.FLunaProgramacionNCapasEntities context = new DL_EF.FLunaProgramacionNCapasEntities())
                {
                    var query = context.DepartamentoUpdate(departamento.IdDepartamento, departamento.Nombre, departamento.Area.IdArea);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo hacer update del registro";
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
     public static ML.Result Delete(ML.Departamento departamento)
     {
       ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.FLunaProgramacionNCapasEntities context = new DL_EF.FLunaProgramacionNCapasEntities())
                {
                    var query = context.DepartamentoDelete(departamento.IdDepartamento);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
      
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar registro";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct= false;
                result.ErrorMessage= ex.Message;
            }
            return result;
     }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.FLunaProgramacionNCapasEntities context = new DL_EF.FLunaProgramacionNCapasEntities()) 
                {
                    var query = context.DepartamentoGetAll().ToList();
                    result.Objects = new List<object>();
                    if(query != null)
                    {
                        foreach(var obj in query)
                        {
                            ML.Departamento departamento = new ML.Departamento();

                            departamento.IdDepartamento = obj.IdDepartamento;
                            departamento.Nombre = obj.Nombre;

                            departamento.Area = new ML.Area();
                            departamento.Area.IdArea = obj.IdArea.Value;

                            result.Objects.Add(departamento);
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay registros";
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
        public static ML.Result GetById(int IdDepartamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.FLunaProgramacionNCapasEntities context = new DL_EF.FLunaProgramacionNCapasEntities())
                {
                    var objquery = context.DepartamentoGetById(IdDepartamento).FirstOrDefault();
                    if (objquery != null)
                    {
                        ML.Departamento departamento = new ML.Departamento();

                        departamento.IdDepartamento = objquery.IdDepartamento;
                        departamento.Nombre = objquery.Nombre;

                        departamento.Area = new ML.Area();
                        departamento.Area.IdArea = objquery.IdArea.Value;
                        result.Object = departamento;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo mostar el registro de la tabla";

                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct= false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
  } 
}
