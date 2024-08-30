using CommercioCarrito.Modelo;
using CommercioCarrito.Persistencia;
using MediatR;

namespace CommercioCarrito.Aplicacion
{
    public class Nuevo
    {

        public class Ejecuta : IRequest {
            public  DateTime FechaCreacion { get; set; }
            public List<int> ProductosLista { get; set; }

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
                var carritoSesion = new CarritoSesion
                {
                    FechaCreacion = request.FechaCreacion,
                };
                _context.CarritoSesions.Add(carritoSesion);
                var value = await _context.SaveChangesAsync();
                if(value == 0)
                {
                    throw new Exception("Error en inserción!!!");
                }

                int id = carritoSesion.Id;

                foreach(var detalle in request.ProductosLista)
                {
                    var detalleSesion = new CarritoSesionDetalle
                    {
                        FechaCreacion = DateTime.Now,
                        CarritoSesionId = id,
                        IdProducto = detalle,
                    };
                    _context.CarritoSesionDetalles.Add(detalleSesion);
                }

                await _context.SaveChangesAsync();

            }
        }














    }
}
