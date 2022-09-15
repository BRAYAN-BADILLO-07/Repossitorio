using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class Usuario
    {
        public static ML.Result AddSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "UsuarioAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[11];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("Sexo", SqlDbType.Char);
                        collection[3].Value = usuario.Sexo;

                        collection[4] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[4].Value = usuario.Email;

                        collection[5] = new SqlParameter("FechaDeNacimiento", SqlDbType.VarChar);
                        collection[5].Value = usuario.FechaNacimiento;

                        collection[6] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[6].Value = usuario.Telefono;

                        collection[7] = new SqlParameter("Celular", SqlDbType.VarChar);
                        collection[7].Value = usuario.Celular;

                        collection[8] = new SqlParameter("Curp", SqlDbType.VarChar);
                        collection[8].Value = usuario.Curp;

                        collection[9] = new SqlParameter("UserName", SqlDbType.VarChar);
                        collection[9].Value = usuario.UserName;

                        collection[10] = new SqlParameter("Contrasenia", SqlDbType.VarChar);
                        collection[10].Value = usuario.Constrasenia;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();
                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
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

        public static ML.Result UpdateSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "UsuarioUpdate";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[12];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;


                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaterno;

                        collection[4] = new SqlParameter("Sexo", SqlDbType.Char);
                        collection[4].Value = usuario.Sexo;

                        collection[5] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[5].Value = usuario.Email;

                        collection[6] = new SqlParameter("FechaDeNacimiento", SqlDbType.VarChar);
                        collection[6].Value = usuario.FechaNacimiento;

                        collection[7] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[7].Value = usuario.Telefono;

                        collection[8] = new SqlParameter("Celular", SqlDbType.VarChar);
                        collection[8].Value = usuario.Celular;

                        collection[9] = new SqlParameter("Curp", SqlDbType.VarChar);
                        collection[9].Value = usuario.Curp;

                        collection[10] = new SqlParameter("UserName", SqlDbType.VarChar);
                        collection[10].Value = usuario.UserName;

                        collection[11] = new SqlParameter("Contrasenia", SqlDbType.VarChar);
                        collection[11].Value = usuario.Constrasenia;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();
                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
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
        public static ML.Result DeleteSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "UsuarioDelete";
                    using (SqlCommand cmd = new SqlCommand())

                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;


                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();
                        if (RowsAffected > 0)
                        {
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                        }
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
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "UsuarioGetAll";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tableUsuario = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableUsuario);

                        if (tableUsuario.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableUsuario.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();

                                usuario.IdUsuario = int.Parse(row[0].ToString());
                                usuario.Nombre = row[1].ToString();
                                usuario.ApellidoPaterno = row[2].ToString();
                                usuario.ApellidoMaterno = row[3].ToString();
                                usuario.Sexo = row[4].ToString();
                                usuario.Email = row[5].ToString();
                                usuario.FechaNacimiento = row[6].ToString();
                                usuario.Telefono = row[7].ToString();
                                usuario.Celular = row[8].ToString();
                                usuario.Curp = row[9].ToString();
                                usuario.UserName = row[10].ToString();
                                usuario.Constrasenia = row[11].ToString();

                                result.Objects.Add(usuario);
                                //result.Object = usuario
                            }
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                        }

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
        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "UsuarioGetById";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = IdUsuario;

                        cmd.Parameters.AddRange(collection);

                        DataTable tableUsuario = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableUsuario);

                        if (tableUsuario.Rows.Count > 0)
                        {
                            DataRow row = tableUsuario.Rows[0];
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.Nombre = row[1].ToString();
                            usuario.ApellidoPaterno = row[2].ToString();
                            usuario.ApellidoMaterno = row[3].ToString();
                            usuario.Sexo = row[4].ToString();
                            usuario.Email = row[5].ToString();
                            usuario.FechaNacimiento = row[6].ToString();
                            usuario.Telefono = row[7].ToString();
                            usuario.Celular = row[8].ToString();
                            usuario.Curp = row[9].ToString();
                            usuario.UserName = row[10].ToString();
                            usuario.Constrasenia = row[11].ToString();

                            result.Object = usuario; //BOXING: es el proceso de convertir un tipo de dato a objeto//
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;

                        }
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
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.FLunaProgramacionNCapasEntities context = new DL_EF.FLunaProgramacionNCapasEntities())
                {
                   var query = context.UsuarioGetAll().ToList();
                    result.Objects = new List<object>();
                    if(query !=null)
                    {
                        foreach(var obj in query)
                        {
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

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol=obj.IdRol.Value;
                            usuario.Rol.Nombre = obj.RolNombre;

                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.IdDireccion = obj.IdDireccion;
                            usuario.Direccion.Calle = obj.Calle;
                            usuario.Direccion.NumeroInterior = obj.NumeroInterior;
                            usuario.Direccion.NumeroExterior = obj.NumeroExterior;

                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.IdColonia = obj.IdColonia;
                            result.Objects.Add(usuario);
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
            catch(Exception ex)
            {   
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetByIdEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();
             try
             {
                using(DL_EF.FLunaProgramacionNCapasEntities context  = new DL_EF.FLunaProgramacionNCapasEntities())
                {
                    var objquery = context.UsuarioGetById(IdUsuario).FirstOrDefault();
                    if(objquery != null)
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

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = objquery.IdRol.Value;

                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = objquery.IdDireccion;
                        usuario.Direccion.Calle = objquery.Calle;
                        usuario.Direccion.NumeroInterior = objquery.NumeroInterior;
                        usuario.Direccion.NumeroExterior = objquery.NumeroExterior;

                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = objquery.IdColonia;
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
        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.FLunaProgramacionNCapasEntities context = new DL_EF.FLunaProgramacionNCapasEntities())
                {

                    var query = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Sexo, usuario.Email, usuario.FechaNacimiento, usuario.Telefono, usuario.Celular, usuario.Curp, usuario.UserName, usuario.Constrasenia, usuario.Rol.IdRol, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);
                    if(query>=1)
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
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.FLunaProgramacionNCapasEntities context = new DL_EF.FLunaProgramacionNCapasEntities())
                {
                    var query = context.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Sexo, usuario.Email, usuario.FechaNacimiento, usuario.Telefono, usuario.Celular, usuario.Curp, usuario.UserName, usuario.Constrasenia, usuario.Rol.IdRol, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);
                    if(query>=1)
                    {
                        result.Correct = true;
                        
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo registrar";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage=ex.Message;
            }
            return result;
        }   
        public static ML.Result DeleteEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.FLunaProgramacionNCapasEntities context = new DL_EF.FLunaProgramacionNCapasEntities())
                {
                    var query = context.UsuarioDelete(usuario.IdUsuario);
                    if(query >=1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al eliminar registro";
                    }
                    result.Correct = true;
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage= ex.Message;
            }
            return result;
        }
        public static ML.Result AddLinq(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.FLunaProgramacionNCapasEntities context = new DL_EF.FLunaProgramacionNCapasEntities())
                {
                    DL_EF.Usuario usuarioLinq = new DL_EF.Usuario();

                    usuarioLinq.IdUsuario = usuario.IdUsuario;
                    usuarioLinq.Nombre = usuario.Nombre;
                    usuarioLinq.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioLinq.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioLinq.Sexo = usuario.Sexo;
                    usuarioLinq.Email = usuario.Email;
                    usuarioLinq.FechaDeNacimiento = DateTime.Parse(usuario.FechaNacimiento);
                    usuarioLinq.Telefono=usuario.Telefono;
                    usuarioLinq.Celular = usuario.Celular;
                    usuarioLinq.Curp = usuario.Curp;
                    usuarioLinq.UserName=usuario.UserName;
                    usuarioLinq.Contrasenia = usuario.Constrasenia;
                    usuarioLinq.IdRol = usuario.Rol.IdRol;

                    if (usuarioLinq != null)
                    {
                        context.Usuarios.Add(usuarioLinq);
                        context.SaveChanges();
                        result.Correct = true;
                    }
                    else 
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage=ex.Message;
            }
            return result;
        }
       public static ML.Result GetAllLinq()
        {
            ML.Result result = new ML.Result();
            try 
            {
                using (DL_EF.FLunaProgramacionNCapasEntities context = new DL_EF.FLunaProgramacionNCapasEntities())
                {
                    var usuarios = (from usuariolinq in context.Usuarios
                                    select usuariolinq).ToList();
                    if(usuarios != null)
                    {
                        result.Objects = new List<object>();
                        foreach( var objUsuario in usuarios)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = objUsuario.IdUsuario;
                            usuario.Nombre = objUsuario.Nombre;
                            usuario.ApellidoPaterno = objUsuario.ApellidoPaterno;
                            usuario.ApellidoMaterno = objUsuario.ApellidoMaterno;
                            usuario.Sexo = objUsuario.Sexo;
                            usuario.Email = objUsuario.Email;
                            usuario.FechaNacimiento = objUsuario.FechaDeNacimiento.ToString();
                            usuario.Telefono = objUsuario.Telefono;
                            usuario.Celular = objUsuario.Celular;
                            usuario.Curp = objUsuario.Curp;
                            usuario.UserName = objUsuario.UserName;
                            usuario.Constrasenia = objUsuario.Contrasenia;

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = objUsuario.Rol.IdRol;

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
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
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result UpdateLinq(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.FLunaProgramacionNCapasEntities context = new DL_EF.FLunaProgramacionNCapasEntities())
                {
                    var usuarioLinq = (from a in context.Usuarios
                                       where a.IdUsuario == usuario.IdUsuario
                                       select a).SingleOrDefault();
                    if(usuarioLinq != null)
                    {
                        usuarioLinq.Nombre = usuario.Nombre;
                        usuarioLinq.ApellidoPaterno = usuario.ApellidoPaterno;
                        usuarioLinq.ApellidoMaterno = usuario.ApellidoMaterno;
                        usuarioLinq.Sexo = usuario.Sexo;
                        usuarioLinq.Email = usuario.Email;
                        usuarioLinq.FechaDeNacimiento = DateTime.Parse(usuario.FechaNacimiento);
                        usuarioLinq.Telefono = usuario.Telefono;
                        usuarioLinq.Celular = usuario.Celular;
                        usuarioLinq.Curp = usuario.Curp;
                        usuarioLinq.UserName = usuario.UserName;
                        usuarioLinq.Contrasenia = usuario.Constrasenia;
                        usuarioLinq.Rol.IdRol = usuario.Rol.IdRol;

                        result.Correct = true;
                    }
                    else 
                    {
                        result.Correct = false;
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
        public static ML.Result DeleteLinq(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.FLunaProgramacionNCapasEntities context = new DL_EF.FLunaProgramacionNCapasEntities())
                {
                    var usuarioLinq = (from a in context.Usuarios
                                       where a.IdUsuario == usuario.IdUsuario
                                       select a).First();
                    if(usuarioLinq != null)
                    {
                        usuarioLinq.IdUsuario = usuarioLinq.IdUsuario;

                        result.Correct = true;

                    }

                    context.Usuarios.Remove(usuarioLinq);
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                result.Correct =false;
                result.ErrorMessage=ex.Message;
            }
            return result;
        }
        public static ML.Result GeyByIdLinq(int Idusuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.FLunaProgramacionNCapasEntities context = new DL_EF.FLunaProgramacionNCapasEntities())
                {
                    var query = (from usuarioLinq in context.Usuarios
                                 where usuarioLinq.IdUsuario == Idusuario
                                 select usuarioLinq).FirstOrDefault();
                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = query.IdUsuario;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.Sexo = query.Sexo;
                        usuario.Email = query.Email;
                        usuario.FechaNacimiento = query.FechaDeNacimiento.ToString();
                        usuario.Telefono = query.Telefono;
                        usuario.Celular = query.Celular;
                        usuario.Curp = query.Curp;
                        usuario.UserName = query.UserName;
                        usuario.Constrasenia = query.Contrasenia;

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = query.IdRol.Value;

                        result.Object = usuario;
                        result.Correct = true;
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
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

    }  
}
