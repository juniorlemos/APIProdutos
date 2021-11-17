using AutoMapper;
using Modelo.Application.DTOs;
using Modelo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Application.Mappers
{
    public class MappingProfileProduto : Profile
    {
        public MappingProfileProduto()
        {
            CreateMap<ProdutoDto, Produto>().ReverseMap();
        }
    }
}
