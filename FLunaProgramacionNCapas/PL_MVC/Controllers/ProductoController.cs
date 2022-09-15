using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Producto producto = new ML.Producto();
            ML.Result result = BL.Producto.GetAll();
            if(result.Correct)
            {
                producto.Productos = result.Objects;
            }
            return View(producto);
        }
        [HttpGet]
        public ActionResult Form(int? IdProducto)
        {
            ML.Producto producto = new ML.Producto();
            producto.Proveedor = new ML.Proveedor();
            producto.Departamento = new ML.Departamento();


            if(IdProducto == null)
            {
                return View(producto);
            }
            else
            {
                ML.Result result = new ML.Result();
                result = BL.Producto.GetById(IdProducto.Value);
                if (result.Correct)
                {
                    producto = ((ML.Producto)result.Object);
                    return View(producto);
                }
               
            }
            return View();
        }
        [HttpPost]
        public ActionResult Form(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            if(producto.IdProducto == 0)
            {
                result = BL.Producto.Add(producto);

                if(result.Correct)
                {
                    ViewBag.Mensaje = "Registro exitoso";
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un problema al agregar el registo";
                }
            }
            else
            {
                result = BL.Producto.Update(producto);

                if(result.Correct)
                {
                    ViewBag.Mensaje = "Update Exitoso";
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un problema al actualizar";
                }
            }
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Delete(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            result = BL.Producto.Delete(producto);
            if(result.Correct)
            {
                ViewBag.Mensaje = "Registro eliminado con exito";
            }
            else
            {
                ViewBag.Mensaje = "Ocurrio un problema al eliminar el registro";
            }
            return PartialView("Modal");
        }   
    }
}