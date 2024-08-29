using Libros.Aplicacion;
using Libros.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroMaterialController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public LibroMaterialController(IMediator mediatr)
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
                  
        }


        [HttpGet]
        public async Task<ActionResult> GetLibros()
        {
            try
            {
                var data = await _mediatr.Send(new Consulta.Ejecuta());
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpGet("Id:int")]
        public async Task<ActionResult<LibroMaterialDTO>> GetLibro(int Id)
        {

            try
            {
                var libro = await _mediatr.Send(new ConsultaParametrizada.Consulta{ Id = Id });
                if (libro == null)
                {
                    return NotFound();
                }
                return Ok(libro);
            }

            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}
