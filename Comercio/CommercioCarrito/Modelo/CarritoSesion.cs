namespace CommercioCarrito.Modelo
{
    public class CarritoSesion
    {
        public int Id { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public List<CarritoSesionDetalle> ListaDetalle { get; set; }
    }
}
