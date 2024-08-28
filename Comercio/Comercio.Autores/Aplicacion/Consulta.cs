using AutoMapper;
using Comercio.Autores.DTOs;
using Comercio.Autores.Modelo;
using Comercio.Autores.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Comercio.Autores.Aplicacion
{
    public class Consulta
    {

        public class ListaAutor : IRequest<List<AutorLibroDTO>>
        {

        }


        public class Manejador : IRequestHandler<ListaAutor, List<AutorLibroDTO>>
        {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;

            public Manejador(ApplicationDbContext context, IMapper mapper)
            {
                this._context = context;
                this._mapper = mapper;
            }

            public async Task<List<AutorLibroDTO>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                return  _mapper.Map<List<AutorLibroDTO>>(await _context.AutoresLibros.ToListAsync());

            }
        }

    }
}
