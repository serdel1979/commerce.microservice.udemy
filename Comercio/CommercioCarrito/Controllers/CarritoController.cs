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


        [HttpGet("id:int")]
        public async Task<ActionResult> GetCar(int id)
        {
            try
            {
                var car = await _mediatr.Send(new Consulta.Ejecuta { CarritoId = id});
                return Ok(car);
        }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCar()
        {
            try
            {
                var cars = await _mediatr.Send(new Todos.Ejecuta());
            return Ok(cars);
        }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}
