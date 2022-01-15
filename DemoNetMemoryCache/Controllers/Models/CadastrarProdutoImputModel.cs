using DemoNetMemoryCache.Models;
using FluentValidation;
using FluentValidation.Results;

namespace DemoNetMemoryCache.Controllers.Models;
public class CadastrarProdutoImputModel
{
    public string Nome { get; set; }
    public string Departamento { get; set; }
    public decimal Preco { get; set; }

    public ValidationResult EstaValido()
    {
        return new CadastrarProdutoImputModelValidation().Validate(this);
    }
}

public class CadastrarProdutoImputModelValidation : AbstractValidator<CadastrarProdutoImputModel>
{
    public CadastrarProdutoImputModelValidation()
    {
        RuleFor(c => c.Nome)
        .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
        .Length(Produto.TamanhoTextoMinimo, Produto.TamanhoNome).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(c => c.Departamento)
        .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
        .Length(Produto.TamanhoTextoMinimo, Produto.TamanhoDepartamento).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

    }
}