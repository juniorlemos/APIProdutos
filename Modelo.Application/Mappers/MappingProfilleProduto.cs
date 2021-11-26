using AutoMapper;
using Modelo.Application.DTOs;
using Modelo.Application.DTOs.ModelView;
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
            CreateMap<ProdutoView, Produto>().ReverseMap();
        }
    }
}
