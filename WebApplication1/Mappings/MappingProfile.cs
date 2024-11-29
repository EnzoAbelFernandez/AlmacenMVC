using AlmacenMVC.Dtos;
using AlmacenMVC.Models;
using AutoMapper;

namespace TiendaAlmacenMVC.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Articulo, ArticuloDto>().ReverseMap();
        }
    }
}
