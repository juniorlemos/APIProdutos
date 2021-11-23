using FluentValidation;
using Modelo.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Application.Validators
{
   public  class AlteraProdutoDtoValidator :AbstractValidator<AlteraProdutoDto>
    {
        public AlteraProdutoDtoValidator()
        {
            RuleFor(p => p.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
            Include(new ProdutoDtoValidator());
        }
    }
}
