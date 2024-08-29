using AutoMapper;
using Libros.DTOs;
using Libros.Modelo;

namespace Libros.Mapeo
{
    public class MapeoObjetos : Profile
    {

        public MapeoObjetos()
        {
            CreateMap<LibreriaMaterial, LibroMaterialDTO>().ReverseMap();
        }

    }
}
