﻿namespace Libros.Modelo
{
    public class LibreriaMaterial
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public int? IdAutor { get; set; }
    }
}
