using DemoNetMemoryCache.Models;

namespace DemoNetMemoryCache.Repositorios.Categorias
{
    public interface ICategoriaRepositorioQuery
    {
        Task<Categoria> ObterPorId(Guid id);
        Task<IEnumerable<Categoria>> ObterTodos();
    }
}