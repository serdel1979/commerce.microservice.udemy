namespace CommercioCarrito.Modelo
{
    public class CarritoSesion
    {
        public int Id { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public ICollection<CarritoSesionDetalle> ListaDetalle { get; set; }
    }
}
