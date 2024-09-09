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
                try
                {

                    var car = await _context.CarritoSesions.Include(d=>d.ListaDetalle)
                        .FirstOrDefaultAsync(c => c.Id == request.CarritoId);

                    var detalleCarrito = car.ListaDetalle;


                    var listaCarritoDto = new List<DetalleDTO>();

                    foreach(var libro in detalleCarrito)
                    {
                        var resp =  await _libroService.GetLibro(libro.IdProducto);
                        if (resp.Resultado)
                        {
                            var objetoLibro = resp.Libro;
                            var carritoDetalle = new DetalleDTO
                            {
                                Producto = objetoLibro.Titulo,
                                FechaCreacion = objetoLibro.FechaPublicacion,
                                Id = objetoLibro.Id,
                            };
                            listaCarritoDto.Add(carritoDetalle);
                        }
                    }

                    var carritoDto = new CarritoDTO
                    {
                        Id = car.Id,
                        FechaCreacion = car.FechaCreacion,
                        ListaDetalle = listaCarritoDto
                    };

                    return carritoDto;
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }


    }
}
