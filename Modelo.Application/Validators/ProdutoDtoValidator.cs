using FluentValidation;
using Modelo.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Application.Validators
{
    public class ProdutoDtoValidator : AbstractValidator<ProdutoDto>
    {
        public ProdutoDtoValidator()
        {
            RuleFor(p => p.Nome)
                .NotNull().WithMessage("Nome não pode ser nulo")
                .NotEmpty().WithMessage("Nome não poder ser vazio")
                .MaximumLength(50).WithMessage("Digite no máximo  50 caracteres")
                .MinimumLength(4).WithMessage("Digite no minimo 4 caracteres");
        }
    }
}
