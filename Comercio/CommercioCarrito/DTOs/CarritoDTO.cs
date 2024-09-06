using CommercioCarrito.Modelo;

namespace CommercioCarrito.DTOs
{
    public class CarritoDTO
    {
        public int Id { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public List<DetalleDTO> ListaDetalle { get; set; }
    }
}
