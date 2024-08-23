using Comercio.Autores.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Comercio.Autores.Persistencia
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public  DbSet<AutorLibro> AutoresLibros { get; set; }
        public DbSet<GradoAcademico> GradoAcademicos { get; set; }

    }
}
