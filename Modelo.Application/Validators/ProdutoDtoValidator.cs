using FluentValidation;
using Modelo.Application.DTOs;

namespace Modelo.Application.Validators
{
    public class ProdutoDtoValidator : AbstractValidator<ProdutoDto>
    {
        public ProdutoDtoValidator()
        {
            RuleFor(p => p.Nome)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(4);
        }
    }
}
