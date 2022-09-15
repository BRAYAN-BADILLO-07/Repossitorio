using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario(); // instancia para las propiedades
            ML.Result result = BL.Usuario.GetAll();

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
                return View(usuario);
            }
            return View(usuario);
        }
        [HttpGet]
        public ActionResult Form(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result resultRol = BL.Rol.GetAll();
            ML.Result resultPais = BL.Pais.GetAll();
            
            usuario.Rol = new ML.Rol();
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

            if (IdUsuario == null) // add
            {
                
                usuario.Rol.Roles = resultRol.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                return View(usuario);
            }
            else//update
            {
                ML.Result result = BL.Usuario.GetById(IdUsuario.Value);

                if (result.Correct)
                {
                    usuario = ((ML.Usuario)result.Object); // Unboxing
                    //Instancias para acceder a la informacion del unboxing
                    ML.Result resultEstado = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
                    ML.Result resultMunicipio = BL.Municipio.MunicipioGetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                    ML.Result resultColonia = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);
                    //son necesarios para mantener la informacion del unboxing
                    usuario.Rol.Roles = resultRol.Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstado.Objects;
                    usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipio.Objects;
                    usuario.Direccion.Colonia.Colonias = resultColonia.Objects;

                    return View(usuario);
                }
                else
                {
                    ViewBag.Mensaje = "Se produjo un error" + result.ErrorMessage;
                    return View("Modal");
                }
            }         
        }
        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            if (usuario.IdUsuario == 0)
            {
                ML.Result result = new ML.Result();
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Registro de manera exitoso";
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un problema al agregar registro";
                }
            }
            else
            {
                ML.Result result = BL.Usuario.Update(usuario);
                if(result.Correct)
                {
                    ViewBag.Mensaje = "Update con exito";
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un problema al actualizar registro";
                }
            }
            return PartialView("Modal");
        }

        public JsonResult EstadoGetByIdPais(int IdPais)
        {
            ML.Result result = BL.Estado.GetByIdPais(IdPais);

            return Json(result.Objects);
        }

        public JsonResult MunicipioGetByIdEstado(int IdEstado)
        {
            ML.Result result = BL.Municipio.MunicipioGetByIdEstado(IdEstado);
            return Json(result.Objects);
        }

        public JsonResult ColoniaGetByIdMunicipio(int IdMunicipio)
        {
            ML.Result result = BL.Colonia.GetByIdMunicipio(IdMunicipio);
            return Json(result.Objects);
        }
        public static byte[] ConvertToBytes(IFormFile imagen)
        {
            using var fileStream = imagen.OpenReadStream();

            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);

            return bytes;
        }
        public ActionResult Delete(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            result = BL.Usuario.Delete(usuario);

            if (result.Correct)
            {
                ViewBag.Mensaje = "Registro Eliminado Con Exitoso";
            }
            else
            {
                ViewBag.Mensaje = "Se A Producido Un Error" + result.ErrorMessage;
            }
            return PartialView("Modal");
        }
    }      
}
