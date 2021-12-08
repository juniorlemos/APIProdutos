using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelo.Domain.Entities;

namespace Modelo.Infra.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {

            builder.ToTable("Produto");

            builder.HasKey(prop => prop.Id);

            builder.HasIndex(prop => prop.Nome);

            builder.Property(prop => prop.Nome)
                .IsRequired()
                .HasMaxLength(60);




        }
    }
}
