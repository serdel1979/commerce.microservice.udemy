using Comercio.Autores.Aplicacion;
using Comercio.Autores.Modelo;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Comercio.Autores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public AutorController(IMediator mediatr)
        {
            this._mediatr = mediatr;
        }



        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Nuevo.Ejecuta data) {

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


        [HttpGet]
        public async Task<ActionResult<List<AutorLibro>>> GetAutoresLibros()
        {
            return await _mediatr.Send(new Consulta.ListaAutor());
        }

        [HttpGet("Id:int")]
        public async Task<ActionResult<AutorLibro>> GetAutor(int Id)
        {

            try
            {
                var autor = await _mediatr.Send(new ConsultaFiltro.AutorUnico { AutorId = Id });
                if (autor == null)
                {
                    return NotFound();
                }
                return Ok(autor);
            }

            catch (Exception)
            {
                return BadRequest();
            }
        }



    }
}
