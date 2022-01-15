# DemoNetMemoryCache
Demo de utilização de Memória em Cache em .NET


Instalar o pacote para o gerenciamento de Cache
```
dotnet add package Microsoft.Extensions.Caching.Memory --version 6.0.0

Temos a opção de MemoryCacheOptions que nos permite definir alguns comportamentos sobre o cache.
.SetSlidingExpiration: Tempo de expiração do cache. Porém, só vai expirar se não ocorrer nenhuma chamada para aquele Cache naquele intervalo.
.Set: 