using AutoMapper;
using Modelo.Application.DTOs;
using Modelo.Application.DTOs.ModelView;
using Modelo.Domain.Entities;

namespace Modelo.Application.Mappers
{
    public class MappingProfileProduto : Profile
    {
        public MappingProfileProduto()
        {
            CreateMap<ProdutoDto, Produto>().ReverseMap();
            CreateMap<ProdutoView, Produto>().ReverseMap();
        }
    }
}
