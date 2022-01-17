using DemoNetMemoryCache.Models;
using FluentValidation;
using FluentValidation.Results;

namespace DemoNetMemoryCache.Controllers.Models;
public class CadastrarCategoriaImputModel
{
    public string Descricao { get; set; }    
    public ValidationResult EstaValido()
    {
        return new CadastrarCategoriaImputModelValidation().Validate(this);
    }
}

public class CadastrarCategoriaImputModelValidation : AbstractValidator<CadastrarCategoriaImputModel>
{
    public CadastrarCategoriaImputModelValidation()
    {
        RuleFor(c => c.Descricao)
        .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
        .Length(Produto.TamanhoTextoMinimo, Produto.TamanhoNome).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        
    }
}