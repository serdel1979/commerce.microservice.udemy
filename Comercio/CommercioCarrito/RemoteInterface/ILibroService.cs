using CommercioCarrito.RemoteModel;

namespace CommercioCarrito.RemoteInterface
{
    public interface ILibroService
    {
        Task<(bool Resultado,LibroRemote Libro)> GetLibro(int Id);
    }
}
