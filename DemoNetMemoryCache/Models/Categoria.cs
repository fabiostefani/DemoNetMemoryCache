namespace DemoNetMemoryCache.Models
{
    public class Categoria
    {
        public const int TamanhoMinimo = 3;
        public const int TamanhoMaximoDescricao = 200;
        public Categoria(string descricao)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
        }
        public Guid Id { get; private set; }
        public string Descricao { get; private set; }        
    }
}