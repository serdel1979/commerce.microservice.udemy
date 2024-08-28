using Comercio.Autores.Modelo;

namespace Comercio.Autores.DTOs
{
    public class AutorLibroDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
    }
}
