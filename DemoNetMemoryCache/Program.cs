using DemoNetMemoryCache.Data;
using DemoNetMemoryCache.Repositorios;
using DemoNetMemoryCache.Repositorios.Caching;
using DemoNetMemoryCache.Repositorios.Categorias;
using DemoNetMemoryCache.Repositorios.Produtos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MemoryCacheContext>(options =>
                options.UseNpgsql(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<MemoryCacheContext>();
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<CategoriaRepositorioQuery>();
builder.Services.AddScoped<ICategoriaRepositorioQuery, CategoriaCachingDecorator<CategoriaRepositorioQuery>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
