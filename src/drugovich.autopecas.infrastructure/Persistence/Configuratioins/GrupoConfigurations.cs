using drugovich.autopecas.core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace drugovich.autopecas.infrastructure.Persistence.Configuratioins;

public class GrupoConfigurations :  IEntityTypeConfiguration<Grupo>
{
    public void Configure(EntityTypeBuilder<Grupo> builder)
    {
        builder.ToTable("GRUPOS");

        builder.HasKey(g => g.Id);

        builder.Property(g => g.Nome)
            .IsRequired();
        
        // Adicione dados iniciais para a tabela Grupo
        builder.HasData(
            new Grupo { Id = 1, Nome = "Grupo A" },
            new Grupo { Id = 2, Nome = "Grupo B" }
        );
    }
}