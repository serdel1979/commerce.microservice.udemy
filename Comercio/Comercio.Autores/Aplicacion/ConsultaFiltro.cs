using MediatR;
using Comercio.Autores.Modelo;
using Comercio.Autores.Persistencia;
using Microsoft.EntityFrameworkCore;
using Comercio.Autores.DTOs;
using AutoMapper;

namespace Comercio.Autores.Aplicacion
{
    public class ConsultaFiltro
    {

        public class AutorUnico : IRequest<AutorLibroDTO>
        {
            public int AutorId { get; set; }
        }

        public class Manejador : IRequestHandler<AutorUnico, AutorLibroDTO>
        {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;

            public Manejador(ApplicationDbContext context, IMapper mapper)
            {
                this._context = context;
                this._mapper = mapper;
            }

            public async Task<AutorLibroDTO> Handle(AutorUnico request, CancellationToken cancellationToken)
            {

                return _mapper.Map<AutorLibroDTO>(await _context.AutoresLibros.Where(a => a.AutorLibroId == request.AutorId).FirstOrDefaultAsync());
    
            }
        }

    }
}
