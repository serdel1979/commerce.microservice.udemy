using CommercioCarrito.Aplicacion;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommercioCarrito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public CarritoController(IMediator mediatr)
        {
            this._mediatr = mediatr;
        }

        [HttpPost]
        public async Task<ActionResult> Crear(Nuevo.Ejecuta data)
        {
            try
            {
                await _mediatr.Send(data);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}
