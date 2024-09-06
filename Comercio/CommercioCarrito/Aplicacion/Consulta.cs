using AutoMapper;
using CommercioCarrito.DTOs;
using CommercioCarrito.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommercioCarrito.Aplicacion
{
    public class Consulta
    {

       public class Ejecuta : IRequest<CarritoDTO>
       {
            public int CarritoId { get; set; }
       }



        public class Manejador : IRequestHandler<Ejecuta, CarritoDTO>
        {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;

            public Manejador(ApplicationDbContext context, IMapper mapper)
            {
                this._context = context;
                this._mapper = mapper;
            }
            public async Task<CarritoDTO> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                //var car = _mapper.Map<CarritoDTO>(await _context.CarritoSesions.Where(c=>c.Id ==  request.CarritoId).Include(d=>d.ListaDetalle).FirstOrDefaultAsync());

                               
                var car = await _context.CarritoSesions.Where(c => c.Id == request.CarritoId)
                    .Include(d=>d.ListaDetalle)
                    .FirstOrDefaultAsync();

                var cardto = _mapper.Map<CarritoDTO>(car);
                return cardto;
            }
        }


    }
}
