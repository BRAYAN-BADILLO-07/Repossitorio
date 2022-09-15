using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FLunaProgramacionNCapasContext context = new DL.FLunaProgramacionNCapasContext())
                {

                    var query = context.Database.ExecuteSqlRaw($"UsuarioAdd '{usuario.Nombre}', '{usuario.ApellidoPaterno}', '{usuario.ApellidoMaterno}', '{usuario.Sexo}', '{usuario.Email}','{ usuario.FechaNacimiento}','{usuario.Telefono}', '{usuario.Celular}', '{usuario.Curp}', '{usuario.UserName}', '{usuario.Constrasenia}', {usuario.Rol.IdRol}, '{usuario.Direccion.Calle}', '{usuario.Direccion.NumeroInterior}', '{usuario.Direccion.NumeroExterior}', {usuario.Direccion.Colonia.IdColonia},'{usuario.Imagen}'");
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se inserto el registro";

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
        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FLunaProgramacionNCapasContext context = new DL.FLunaProgramacionNCapasContext())
                {

                    var query = context.Database.ExecuteSqlRaw($"UsuarioAdd {usuario.IdUsuario}, '{usuario.Nombre}', '{usuario.ApellidoPaterno}', '{usuario.ApellidoMaterno}', '{usuario.Sexo}', '{usuario.Email}','{usuario.FechaNacimiento}','{usuario.Telefono}', '{usuario.Celular}', '{usuario.Curp}', '{usuario.UserName}', '{usuario.Constrasenia}', {usuario.Rol.IdRol}, '{usuario.Direccion.Calle}', '{usuario.Direccion.NumeroInterior}', '{usuario.Direccion.NumeroExterior}', {usuario.Direccion.Colonia.IdColonia},'{usuario.Imagen}'");
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se inserto el registro";

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
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FLunaProgramacionNCapasContext context = new DL.FLunaProgramacionNCapasContext())
                {
                    var query = context.Usuarios.FromSqlRaw($"UsuarioGetAll").ToList();

                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach(var obj in query)
                        {
                            //usuario
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.Nombre = obj.Nombre;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.Sexo = obj.Sexo;
                            usuario.Email = obj.Email;
                            usuario.FechaNacimiento = obj.FechaDeNacimiento.ToString();
                            usuario.Telefono = obj.Telefono;
                            usuario.Celular = obj.Celular;
                            usuario.Curp = obj.Curp;
                            usuario.UserName = obj.UserName;
                            usuario.Constrasenia = obj.Contrasenia;
                            usuario.Imagen = obj.Imagen;
                            
                            //ROL
                            usuario.Rol = new ML.Rol(); //VAS A HACER PLANAS! 
                            usuario.Rol.IdRol = obj.IdRol.Value;
                            usuario.Rol.Nombre = obj.RolNombre;

                            //Direccion
                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.IdDireccion = obj.IdDireccion;
                            usuario.Direccion.Calle = obj.Calle;
                            usuario.Direccion.NumeroInterior = obj.NumeroInterior;
                            usuario.Direccion.NumeroExterior = obj.NumeroExterior;
                            //Colonia
                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.IdColonia = obj.IdColonia;
                            usuario.Direccion.Colonia.Nombre = obj.ColoniaNombre;
                            //Municipio
                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.IdMunicipio = obj.IdMunicipio;
                            usuario.Direccion.Colonia.Municipio.Nombre = obj.MunicipioNombre;
                            //Estado
                            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();//VAS A HACER PLANAS
                            usuario.Direccion.Colonia.Municipio.Estado.IdEstado = obj.IdEstado;
                            usuario.Direccion.Colonia.Municipio.Estado.Nombre = obj.EstadoNombre;
                            //Pais
                            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = obj.IdPais;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = obj.PaisNombre;

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar la consulta";
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

        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.FLunaProgramacionNCapasContext context = new DL.FLunaProgramacionNCapasContext())
                {
                    var objquery = context.Usuarios.FromSqlRaw($"UsuarioGetById {IdUsuario}").AsEnumerable().FirstOrDefault();
                    if (objquery != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = objquery.IdUsuario;
                        usuario.Nombre = objquery.Nombre;
                        usuario.ApellidoPaterno = objquery.ApellidoPaterno;
                        usuario.ApellidoMaterno = objquery.ApellidoMaterno;
                        usuario.Sexo = objquery.Sexo;
                        usuario.Email = objquery.Email;
                        usuario.FechaNacimiento = objquery.FechaDeNacimiento.ToString();
                        usuario.Telefono = objquery.Telefono;
                        usuario.Celular = objquery.Celular;
                        usuario.Curp = objquery.Curp;
                        usuario.UserName = objquery.UserName;
                        usuario.Constrasenia = objquery.Contrasenia;
                        usuario.Imagen = objquery.Imagen.ToString();

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = objquery.IdRol.Value;
                        

                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = objquery.IdDireccion;
                        usuario.Direccion.Calle = objquery.Calle;
                        usuario.Direccion.NumeroInterior = objquery.NumeroInterior;
                        usuario.Direccion.NumeroExterior = objquery.NumeroExterior;

                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = objquery.IdColonia;
                        usuario.Direccion.Colonia.Nombre = objquery.ColoniaNombre;

                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = objquery.IdMunicipio;
                        usuario.Direccion.Colonia.Municipio.Nombre = objquery.MunicipioNombre;

                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = objquery.IdEstado;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = objquery.EstadoNombre;

                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = objquery.IdPais;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = objquery.Nombre;

                        result.Object = usuario;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo completar los registros de la tabla";
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
        public static ML.Result Delete(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FLunaProgramacionNCapasContext context = new DL.FLunaProgramacionNCapasContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UsuarioDelete {usuario.IdUsuario}");
                    if (query >=1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al Eliminar Registro";
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
    }
}
