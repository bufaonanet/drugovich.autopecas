using drugovich.autopecas.core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace drugovich.autopecas.infrastructure.Persistence.Configuratioins;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("CLIENTES");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.CNPJ)
            .IsRequired();

        builder.Property(c => c.Nome)
            .IsRequired();

        builder.Property(c => c.DataFundacao)
            .IsRequired();

        builder.HasOne(c => c.Grupo)
            .WithMany(g => g.Clientes)
            .HasForeignKey(c => c.GrupoId);
        
        // Adicione dados iniciais para a tabela Cliente
        builder.HasData(
            new Cliente
            {
                Id = 1, CNPJ = "49341109000181", Nome = "Cliente1",
                DataFundacao = DateTime.Now.AddYears(-1), GrupoId = 1
            },
            new Cliente
            {
                Id = 2, CNPJ = "49341109000181", Nome = "Cliente2",
                DataFundacao = DateTime.Now.AddYears(-1), GrupoId = 2
            }
        );
    }
}