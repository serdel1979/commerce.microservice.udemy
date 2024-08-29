using AutoMapper;
using Libros.DTOs;
using Libros.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Libros.Aplicacion
{
    public class ConsultaParametrizada
    {

        public class Consulta :IRequest<LibroMaterialDTO> {
            public int Id { get; set; }
        }





        public class Manejador : IRequestHandler<Consulta, LibroMaterialDTO>
        {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;

            public Manejador(ApplicationDbContext context, IMapper mapper)
            {
                this._context = context;
                this._mapper = mapper;
            }
            public async Task<LibroMaterialDTO> Handle(Consulta request, CancellationToken cancellationToken)
            {
               return _mapper.Map<LibroMaterialDTO>(await _context.LibreriaMaterials.Where(l=>l.Id == request.Id).FirstOrDefaultAsync());
            }
        }



    }
}
