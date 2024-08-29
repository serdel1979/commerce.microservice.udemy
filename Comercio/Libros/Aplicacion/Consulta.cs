using AutoMapper;
using Libros.DTOs;
using Libros.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Libros.Aplicacion
{
    public class Consulta
    {

        public class Ejecuta: IRequest<List<LibroMaterialDTO>> {}



        public class Manejador : IRequestHandler<Ejecuta, List<LibroMaterialDTO>>
        {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;

            public Manejador(ApplicationDbContext context, IMapper mapper)
            {
                this._context = context;
                this._mapper = mapper;
            }
            public async Task<List<LibroMaterialDTO>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                return _mapper.Map<List<LibroMaterialDTO>>(await _context.LibreriaMaterials.ToListAsync());
            }
        }


    }
}
