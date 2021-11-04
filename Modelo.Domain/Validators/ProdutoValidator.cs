using FluentValidation;
using Modelo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Domain.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                .NotNull().WithMessage("Nome não pode ser nulo")
                .NotEmpty().WithMessage("Nome não poder ser vazio")
                .MaximumLength(50).WithMessage("Digite no máximo  50 caracteres")
                .MinimumLength(4).WithMessage("Digite no minimo 4 caracteres");
        }
    }
}
