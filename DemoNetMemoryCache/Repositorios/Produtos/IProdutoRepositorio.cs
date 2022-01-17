using DemoNetMemoryCache.Models;

namespace DemoNetMemoryCache.Repositorios.Produtos;
public interface IProdutoRepositorio
{
    Task<bool> Adicionar(Produto produto);
    Task<Produto> ObterPorId(Guid id);
    Task<IEnumerable<Produto>> ObterTodos();
}