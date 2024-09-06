using AutoMapper;
using CommercioCarrito.DTOs;
using CommercioCarrito.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommercioCarrito.Aplicacion
{
    public class Todos
    {

        public class Ejecuta : IRequest<List<CarritoSinDetalleDTO>>
        {
        }

        public class Manejador : IRequestHandler<Ejecuta, List<CarritoSinDetalleDTO>>
        {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;

            public Manejador(ApplicationDbContext context, IMapper mapper)
            {
                this._context = context;
                this._mapper = mapper;
            }
            public async Task<List<CarritoSinDetalleDTO>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                return _mapper.Map<List<CarritoSinDetalleDTO>>(await _context.CarritoSesions.ToListAsync());
            }
        }

    }
}
