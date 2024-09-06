using CommercioCarrito.Modelo;

namespace CommercioCarrito.DTOs
{
    public class DetalleDTO
    {
        public int Id { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Producto { get; set; }
        public int IdProducto { get; set; }
    }
}
