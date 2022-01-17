using DemoNetMemoryCache.Controllers.Models;
using DemoNetMemoryCache.Models;
using DemoNetMemoryCache.Repositorios.Categorias;
using DemoNetMemoryCache.Repositorios.Produtos;
using Microsoft.AspNetCore.Mvc;

namespace DemoNetMemoryCache.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly ILogger<Categoria> _logger;
    private readonly ICategoriaRepositorio _categoriaRepositorio;
    private readonly ICategoriaRepositorioQuery _categoriaRepositorioQuery;

    public CategoriaController(ILogger<Categoria> logger,
                             ICategoriaRepositorio categoriaRepositorio,
                             ICategoriaRepositorioQuery categoriaRepositorioQuery)
    {
        _categoriaRepositorioQuery = categoriaRepositorioQuery;
        _logger = logger;
        _categoriaRepositorio = categoriaRepositorio;
    }

    [HttpPost]
    public async Task<ActionResult> Post(CadastrarCategoriaImputModel imputModel)
    {
        var validacao = imputModel.EstaValido();
        if (!validacao.IsValid)
        {
            return BadRequest(validacao.Errors.Select(x => x.ErrorMessage));
        }
        var categoria = new Categoria(imputModel.Descricao);
        var sucesso = await _categoriaRepositorio.Adicionar(categoria);
        return sucesso ? Created(nameof(Get), categoria.Id) : BadRequest(imputModel);
    }

    [HttpGet()]
    [Route("{id:guid}")]
    public async Task<ActionResult> Get(Guid id)
    {
        return Ok(await _categoriaRepositorioQuery.ObterPorId(id));
    }

    [HttpGet()]
    public async Task<ActionResult> Get()
    {
        return Ok(await _categoriaRepositorioQuery.ObterTodos());
    }
}