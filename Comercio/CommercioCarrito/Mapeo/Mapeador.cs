using AutoMapper;
using CommercioCarrito.DTOs;
using CommercioCarrito.Modelo;

namespace CommercioCarrito.Mapeo
{
    public class Mapeador : Profile
    {

        public Mapeador()
        {

             CreateMap<CarritoSesion, CarritoDTO>()
                .ForMember(dest => dest.ListaDetalle, opt => opt.MapFrom(MapDetalle));


            CreateMap<CarritoSesion, CarritoSinDetalleDTO>();

            CreateMap<CarritoSesionDetalle, DetalleDTO>();



        }
       
        private List<DetalleDTO> MapDetalle(CarritoSesion carrito, CarritoDTO carritoDTO)
        {
            var result = new List<DetalleDTO>();
            if (carrito.ListaDetalle == null)
            {
                return result;
            }
            foreach (var detall in carrito.ListaDetalle)
            {
                result.Add(new DetalleDTO
                {
                    Id = detall.Id,
                    FechaCreacion = detall.FechaCreacion,
                    Producto = detall.Producto,
                    IdProducto = detall.IdProducto,
                });
            }
            return result;
        }



    }
}
