using DemoNetMemoryCache.Data;
using DemoNetMemoryCache.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoNetMemoryCache.Repositorios.Categorias
{
    public class CategoriaRepositorioQuery : ICategoriaRepositorioQuery
    {
        private readonly MemoryCacheContext _ctx;

        public CategoriaRepositorioQuery(MemoryCacheContext ctx)
        {
            _ctx = ctx;         
        }

        public async Task<Categoria> ObterPorId(Guid id)
        {
            return await _ctx.Set<Categoria>().FirstOrDefaultAsync(x => x.Id == id);            
        }

        public async Task<IEnumerable<Categoria>> ObterTodos()
        {
            return await _ctx.Set<Categoria>().ToListAsync();        
        }
    }
}