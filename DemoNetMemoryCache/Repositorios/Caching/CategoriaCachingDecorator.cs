using DemoNetMemoryCache.Models;
using DemoNetMemoryCache.Repositorios.Categorias;
using Microsoft.Extensions.Caching.Memory;

namespace DemoNetMemoryCache.Repositorios.Caching;

public class CategoriaCachingDecorator<T> : ICategoriaRepositorioQuery where T : ICategoriaRepositorioQuery
{
    const string KeyMemoryCache = "Categorias";
    private readonly IMemoryCache _memoryCache;
    private readonly T _inner;
    private readonly ILogger<CategoriaCachingDecorator<T>> _logger;
    public CategoriaCachingDecorator(IMemoryCache memoryCache, T inner, ILogger<CategoriaCachingDecorator<T>> logger)
    {
        _logger = logger;
        _memoryCache = memoryCache;
        _inner = inner;
    }

    public async Task<Categoria> ObterPorId(Guid id)
    {
        string keyMemoryCacheCategoriaPorId = $"{KeyMemoryCache}_{id.ToString()}";
        Categoria categoria;
        if (!_memoryCache.TryGetValue(keyMemoryCacheCategoriaPorId, out categoria))
        {
            categoria = await _inner.ObterPorId(id);

            var cacheOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(10))
            .SetAbsoluteExpiration(TimeSpan.FromSeconds(15));

            _memoryCache.Set(keyMemoryCacheCategoriaPorId, categoria, cacheOptions);

            Console.WriteLine("Recuperou do Banco de Dados");
            return categoria;
        }
        return categoria;
    }

    public async Task<IEnumerable<Categoria>> ObterTodos()
    {
        IEnumerable<Categoria> categorias = await _memoryCache.GetOrCreateAsync(KeyMemoryCache, entry =>
        {
            entry.SetSlidingExpiration(TimeSpan.FromSeconds(10));
            entry.SetAbsoluteExpiration(TimeSpan.FromSeconds(15));
            Console.WriteLine("Recuperou do Banco de Dados");
            return _inner.ObterTodos();
        });

        Console.WriteLine("Recuperou do Cache");
        return categorias;
    }
}