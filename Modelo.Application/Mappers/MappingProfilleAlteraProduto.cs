using AutoMapper;
using Modelo.Application.DTOs;
using Modelo.Domain.Entities;

namespace Modelo.Application.Mappers
{
    public class MappingProfilleAlteraProduto : Profile
    {
        public MappingProfilleAlteraProduto()
        {
            CreateMap<AlteraProdutoDto, Produto>().ReverseMap();

        }
    }
}
