using DemoNetMemoryCache.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoNetMemoryCache.Data.Mappings;

public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable(nameof(Categoria));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Descricao)
            .HasMaxLength(Categoria.TamanhoMaximoDescricao)
            .IsRequired()
            .HasColumnName("Descricao")
            .HasColumnType($"varchar({Categoria.TamanhoMaximoDescricao})");
    }
}