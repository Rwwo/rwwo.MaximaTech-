using FluentValidation;

using MaximaTech.api.Models;

namespace MaximaTech.Application.Validator
{
    public class ProdutoValidator : AbstractValidator<Produtos>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Descricao)
                .NotNull()
                .NotEmpty()
                .WithMessage("Descrição de produto é obrigatória");

            RuleFor(p => p.Preco)
                .GreaterThan(0)
                .WithMessage("O preço precisa ser positivo diferente de zero");
        }
    }
}
