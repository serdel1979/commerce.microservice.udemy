using CommercioCarrito.RemoteModel;
using System.Text.Json;

namespace CommercioCarrito.RemoteInterface
{
    public class LibroService : ILibroService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<LibroService> _logger;

        public LibroService(IHttpClientFactory httpClient, ILogger<LibroService> logger)
        {
            this._httpClient = httpClient;
            this._logger = logger;
        }
        public async Task<(bool Resultado, LibroRemote Libro)> GetLibro(int Id)
        {

            try
            {
                var cliente = _httpClient.CreateClient("Libros");
                var response = await  cliente.GetAsync($"api/LibroMaterial/{Id}");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true,
                    };
                    var resultado = JsonSerializer.Deserialize<LibroRemote>(contenido, options);

                    return (true, resultado);
                }
                return (false, null);
            }
            catch (Exception e)
            {
                _logger?.LogError(e.Message);
                return (true, null);
            }

        }
    }
}
