using DemoNetMemoryCache.Data;
using DemoNetMemoryCache.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace DemoNetMemoryCache.Repositorios.Produtos;
public class ProdutoRepositorio : IProdutoRepositorio
{
    const string KeyMemoryCache = "Produtos";

    private readonly MemoryCacheContext _ctx;
    private readonly IMemoryCache _memoryCache;
    public ProdutoRepositorio(MemoryCacheContext ctx,
                             IMemoryCache memoryCache)
    {
        _ctx = ctx;
        _memoryCache = memoryCache;
    }

    public async Task<bool> Adicionar(Produto produto)
    {
        _ctx.Set<Produto>().Add(produto);
        return await _ctx.SaveChangesAsync() > 0;
    }

    public async Task<Produto> ObterPorId(Guid id)
    {
        string keyMemoryCacheProdutoPorId = $"{KeyMemoryCache}_{id.ToString()}";
        Produto produto;
        if (!_memoryCache.TryGetValue(keyMemoryCacheProdutoPorId, out produto))
        {
            produto = await _ctx.Set<Produto>().FirstOrDefaultAsync(x => x.Id == id);
            
            var cacheOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(10))
            .SetAbsoluteExpiration(TimeSpan.FromSeconds(15));

            _memoryCache.Set(keyMemoryCacheProdutoPorId, produto, cacheOptions);

            // _memoryCache.Set(KeyMemoryCache, produtos, TimeSpan.FromSeconds(5));
            Console.WriteLine("Recuperou do Banco de Dados");
            return produto;
        }
        Console.WriteLine("Recuperou do Cache");
        return produto;
    }

    public async Task<IEnumerable<Produto>> ObterTodos()
    {
        IEnumerable<Produto> produtos = await _memoryCache.GetOrCreateAsync(KeyMemoryCache, entry =>
        {
            entry.SetSlidingExpiration(TimeSpan.FromSeconds(10));
            entry.SetAbsoluteExpiration(TimeSpan.FromSeconds(15));            
            Console.WriteLine("Recuperou do Banco de Dados");
            return _ctx.Set<Produto>().ToListAsync();
        });

        Console.WriteLine("Recuperou do Cache");
        return produtos;
    }
}