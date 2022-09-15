using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class ProductoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Producto producto = new ML.Producto(); //instancia
            ML.Result result = BL.Producto.GetAll();

            if(result.Correct)
            {
                producto.Productos = result.Objects;
                return View(producto);
            }
            return View(producto);
        }
       
    }
}
