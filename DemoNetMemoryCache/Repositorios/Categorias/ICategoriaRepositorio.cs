using DemoNetMemoryCache.Models;

namespace DemoNetMemoryCache.Repositorios.Categorias
{
    public interface ICategoriaRepositorio
    {
        Task<bool> Adicionar(Categoria categoria);        
    }
}