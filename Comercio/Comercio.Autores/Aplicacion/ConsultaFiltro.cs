using MediatR;
using Comercio.Autores.Modelo;
using Comercio.Autores.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Comercio.Autores.Aplicacion
{
    public class ConsultaFiltro
    {

        public class AutorUnico : IRequest<AutorLibro>
        {
            public int AutorId { get; set; }
        }

        public class Manejador : IRequestHandler<AutorUnico, AutorLibro>
        {
            private readonly ApplicationDbContext _context;

            public Manejador(ApplicationDbContext context)
            {
                this._context = context;
            }

            public async Task<AutorLibro> Handle(AutorUnico request, CancellationToken cancellationToken)
            {

                var autor = await _context.AutoresLibros.Where(a => a.AutorLibroId == request.AutorId).FirstOrDefaultAsync();
                return autor;
            }
        }

    }
}
