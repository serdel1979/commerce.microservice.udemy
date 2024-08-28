using Comercio.Autores.Modelo;
using Comercio.Autores.Persistencia;
using FluentValidation;
using MediatR;

namespace Comercio.Autores.Aplicacion
{
    public class Nuevo
    {


        public class Ejecuta : IRequest
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime? FechaNacimiento { get; set; }
        }



        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion() 
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Apellido).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly ApplicationDbContext _context;

            public Manejador(ApplicationDbContext context)
            {
                this._context = context;
            }

            public async Task Handle(Ejecuta request, CancellationToken cancellationToken)
            {

                var autor = new AutorLibro
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    FechaNacimiento = request.FechaNacimiento,
                };

                _context.AutoresLibros.Add(autor);
                await _context.SaveChangesAsync();
             }
        }


    }
}
