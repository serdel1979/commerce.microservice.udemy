using AutoMapper;
using CommercioCarrito.DTOs;
using CommercioCarrito.Modelo;

namespace CommercioCarrito.Mapeo
{
    public class Mapper : Profile
    {

        public Mapper()
        {
             CreateMap<CarritoSesion, CarritoDTO>()
                .ForMember(dest => dest.ListaDetalle, opt => opt.MapFrom(src => src.ListaDetalle));

            CreateMap<CarritoSesionDetalle, CarritoDetalleDTO>();
        }


    }
}
