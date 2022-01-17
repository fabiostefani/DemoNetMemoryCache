namespace DemoNetMemoryCache.Models;
public class Produto
{
    public const int TamanhoTextoMinimo = 3;
    public const int TamanhoNome = 200;
    public const int TamanhoDepartamento = 1000;

    public Produto(string nome, string departamento, decimal preco)
    {
        this.Id = Guid.NewGuid();
        this.Nome = nome;
        this.Departamento = departamento;
        this.Preco = preco;
    }
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Departamento { get; private set; }
    public decimal Preco { get; private set; }
    public Guid? CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
}