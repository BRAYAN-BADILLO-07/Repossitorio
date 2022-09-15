using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet]//Action verb controla la accion del metodo
        public ActionResult GetAll() //Action metod metodos que tenemos en el controlador
        {
            ML.Usuario usuario = new ML.Usuario(); // instancia para las propiedades
            ML.Result result = BL.Usuario.GetAllEF();

            if(result.Correct)
            {
                usuario.Usuarios = result.Objects;

            }
            return View(usuario);// action result tipo de retorno que tenemos en los metodos

        }
        [HttpGet]
        public ActionResult Form(int? IdUsuario)
        {
            

            ML.Usuario usuario = new ML.Usuario();

            ML.Result resultRoles = BL.Rol.GetAllEF();
            usuario.Rol = new ML.Rol();

            ML.Pais pais = new ML.Pais(); // instancia para las propiedades
            ML.Result resultPais = BL.Pais.GetAllEF();

            ML.Municipio municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();

            if (IdUsuario == null)
            {

                ML.Result result = new ML.Result();
                usuario.Direccion = new ML.Direccion();
                usuario.Direccion.Colonia = new ML.Colonia();
                usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                usuario.Rol.Roles = resultRoles.Objects;
               
                return View(usuario);
            }
            else
            {
                //Formulario precargado con los datos del registro GetById

                
                ML.Result result = new ML.Result();
                result = BL.Usuario.GetByIdEF(IdUsuario.Value);
                if (result.Correct)
                {
                    
                    usuario = ((ML.Usuario)result.Object);

                    usuario.Rol.Roles = resultRoles.Objects;
                    usuario.Direccion.Direcciones = resultPais.Objects;
                    usuario.Direccion.Colonia.Colonias = resultPais.Objects;
                    usuario.Direccion.Colonia.Municipio.Municipios = resultPais.Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = resultPais.Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;


                    return View(usuario);
                }

            }
            return View();
        }
        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            

            if(usuario.IdUsuario == 0)//Condicion
            {
                ML.Result result = new ML.Result(); //Instancia

                if (result.Correct)
                {
                    
                    
                    ViewBag.Mensaje = "Registro de manera exitoso";
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un problema al agregar el registro" + result.ErrorMessage;
                }
            }
            else
            {
                ML.Result result = BL.Usuario.UpdateEF(usuario); //update

                if(result.Correct)
                {
                    ViewBag.Mensaje = "Update con exito";
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un problema al actualizar registro"+ result.ErrorMessage;
                }
            }
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Delete(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            result = BL.Usuario.DeleteEF(usuario);
            if( result.Correct)
            {
                ViewBag.Mensaje = "Registro Eliminado con exito";
            }
            else
            {
                ViewBag.Mensaje = "Ocurrio un problema al eliminar el registo";
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
    }
}