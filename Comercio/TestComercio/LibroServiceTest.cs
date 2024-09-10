using AutoMapper;
using Libros.Aplicacion;
using Libros.DTOs;
using Libros.Mapeo;
using Libros.Modelo;
using Libros.Persistencia;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenFu;
using Microsoft.EntityFrameworkCore;

namespace TestComercio
{
    public class LibroServiceTest
    {


        private List<LibreriaMaterial> ObtenerDataPrueba()
        {
            A.Configure<LibreriaMaterial>()
                 .Fill(x => x.Titulo).AsArticleTitle()
                 .Fill(x => x.Id);

            var lista = A.ListOf<LibreriaMaterial>(30);
            lista[0].Id = 0;

            return lista;

        }

        private Mock<LibreriaMaterial> CreaContexto()
        {
            var dataPrueba = ObtenerDataPrueba().AsQueryable();
            var dbSet = new Mock<DbSet<LibreriaMaterial>>();

            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x=>x.Provider)
                .Returns(dataPrueba.Provider);

            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.Expression)
                .Returns(dataPrueba.Expression);

            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.ElementType)
                     .Returns(dataPrueba.ElementType);

            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.GetEnumerator())
                .Returns(dataPrueba.GetEnumerator());



        }

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
