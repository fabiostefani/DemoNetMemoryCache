using DemoNetMemoryCache.Data;
using DemoNetMemoryCache.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoNetMemoryCache.Repositorios.Categorias
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly MemoryCacheContext _ctx;

        public CategoriaRepositorio(MemoryCacheContext ctx)
        {
            _ctx = ctx;         
        }

        public async Task<bool> Adicionar(Categoria categoria)
        {
            _ctx.Set<Categoria>().Add(categoria);
            return await _ctx.SaveChangesAsync() > 0;
        }
    }
}