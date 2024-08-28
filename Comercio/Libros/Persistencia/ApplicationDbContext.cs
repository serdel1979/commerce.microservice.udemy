using Libros.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Libros.Persistencia
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<LibreriaMaterial> LibreriaMaterials { get; set; }
    }
}
