# DemoNetMemoryCache

<div style="text-align:center"><img src="https://i.imgur.com/HM1rUb5.png?1" /></div>
<br>

Demo de utilização de Memória em Cache em .NET


Instalar o pacote para o gerenciamento de Cache
```
dotnet add package Microsoft.Extensions.Caching.Memory
```

Adicionar a injeção de dependência
```
builder.Services.AddMemoryCache();
```

Injetar o IMemoryCache no construtor dos objetos que desejo gerenciar.

Chamar os métodos para o gerenciamento.


### Techs utilizadas
 - [**.NET 6**](https://docs.microsoft.com/pt-br/aspnet/core/?WT.mc_id=dotnet-35129-website&view=aspnetcore-6.0)
 - [**FluentValidation.AspNetCore**](https://docs.fluentvalidation.net/en/latest/aspnet.html)
 - [**Microsoft.Extensions.Caching.Memory**](https://docs.microsoft.com/pt-br/dotnet/api/microsoft.extensions.caching.memory.imemorycache?view=dotnet-plat-ext-6.0)

 ### Fonte
 - [**Microsoft**](https://docs.microsoft.com/pt-br/aspnet/core/performance/caching/memory?view=aspnetcore-6.0)