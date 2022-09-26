using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTutorial01.Datos;

namespace WebApplicationTutorial01.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        //El controlador API solo devuelve datos: json, xml, txt, etc ...
        //y el otro controlador devuelve vistas es decir HTML.
        [HttpGet()]
        [Route("ObtenerTodos")]
        public IActionResult ObtenerTodos()
        {
            var listaAlbums = new AlbumsRepository().GetAll();

            return Ok(listaAlbums);
        }
    }
}
