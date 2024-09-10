using AutoMapper;
using Libros.Aplicacion;
using Libros.Mapeo;
using Libros.Persistencia;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestComercio
{
    public class LibroServiceTest
    {

        [Fact]
        public void GetLibros()
        {
            /*
             Necesito emular al context de la base de datos.
             Para eso uso Moq
             */

            var mockContext = new Mock<ApplicationDbContext>();

            /*
             Emuilar el mapeo de automapper
             */
            var mockMapper = new Mock<IMapper>();

            /*
             Ahora instancio lo que sería la logica de negocio
             y le envío los mocks de context y automapper
             */

            Consulta.Manejador handle = new Consulta.Manejador(mockContext.Object,mockMapper.Object);

        }

    }
}
