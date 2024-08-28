using AutoMapper;
using Comercio.Autores.DTOs;
using Comercio.Autores.Modelo;

namespace Comercio.Autores.Mapeo
{
    public class MapeoObjeto : Profile
    {

        public MapeoObjeto()
        {
            CreateMap<AutorLibro, AutorLibroDTO>().ReverseMap();
        }

    }
}
