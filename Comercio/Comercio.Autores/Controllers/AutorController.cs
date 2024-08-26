﻿using Comercio.Autores.Aplicacion;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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


    }
}
