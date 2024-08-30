using CommercioCarrito.Modelo;
using Microsoft.EntityFrameworkCore;

namespace CommercioCarrito.Persistencia
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<CarritoSesion> CarritoSesions { get; set; }
        public DbSet<CarritoSesionDetalle> CarritoSesionDetalles { get; set; }

    }
}
