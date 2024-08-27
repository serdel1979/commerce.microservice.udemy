using Comercio.Autores.Modelo;
using Comercio.Autores.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Comercio.Autores.Aplicacion
{
    public class Consulta
    {

        public class ListaAutor : IRequest<List<AutorLibro>>
        {

        }


        public class Manejador : IRequestHandler<ListaAutor, List<AutorLibro>>
        {
            private readonly ApplicationDbContext _context;

            public Manejador(ApplicationDbContext context)
            {
                this._context = context;
            }

            public async Task<List<AutorLibro>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                return await _context.AutoresLibros.ToListAsync();
            }
        }

    }
}
