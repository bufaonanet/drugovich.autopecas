using drugovich.autopecas.core;
using drugovich.autopecas.core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace drugovich.autopecas.infrastructure.Persistence.Configuratioins;

public class GerenteConfiguration : IEntityTypeConfiguration<Gerente>
{
    public void Configure(EntityTypeBuilder<Gerente> builder)
    {
        builder.ToTable("GERENTES");

        builder.HasKey(g => g.Id);

        builder.Property(g => g.Nome)
            .IsRequired();

        builder.Property(g => g.Email)
            .IsRequired();

        builder.Property(g => g.Nivel)
            .IsRequired();
        
        // Adicione dados iniciais para a tabela Gerente
        builder.HasData(
            new Gerente { Id = 1, Nome = "gerente1", Email = "gerente1@email.com", Nivel = NivelAcesso.Nivel1 },
            new Gerente { Id = 2, Nome = "gerente2", Email = "gerente2@email.com", Nivel = NivelAcesso.Nivel2 }
        );
    }
}