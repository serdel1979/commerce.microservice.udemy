namespace CommercioCarrito.Modelo
{
    public class CarritoSesionDetalle
    {
        public int Id { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Producto { get; set; }

        public int IdProducto { get; set; }
        public int CarritoSesionId { get; set; }
        public CarritoSesion CarritoSesion { get; set; }
    }
}
