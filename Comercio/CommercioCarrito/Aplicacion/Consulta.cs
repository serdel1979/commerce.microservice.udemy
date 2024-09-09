using AutoMapper;
using CommercioCarrito.DTOs;
using CommercioCarrito.Persistencia;
using CommercioCarrito.RemoteInterface;
using CommercioCarrito.RemoteModel;
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
            private readonly ILibroService _libroService;

            public Manejador(ApplicationDbContext context, IMapper mapper,
                ILibroService libroService)
            {
                this._context = context;
                this._mapper = mapper;
                this._libroService = libroService;
            }
            public async Task<CarritoDTO> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                //var car = _mapper.Map<CarritoDTO>(await _context.CarritoSesions.Where(c=>c.Id ==  request.CarritoId).Include(d=>d.ListaDetalle).FirstOrDefaultAsync());
           
                var car = await _context.CarritoSesions.Include(d=>d.ListaDetalle)
                    .FirstOrDefaultAsync(c => c.Id == request.CarritoId);

                var detalleCarrito = await _context.CarritoSesionDetalles
                    .Where(x => x.Id == request.CarritoId).ToListAsync();

                foreach(var libro in detalleCarrito)
                {
                    await _libroService.GetLibro(libro.Id);

                }


                var cardto = _mapper.Map<CarritoDTO>(car);
                return cardto;
            }
        }


    }
}
