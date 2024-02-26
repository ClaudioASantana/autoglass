using GestaoProduto.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutoAgg = GestaoProduto.Domain.ProdutoAggregate;

namespace GestaoProduto.Infrastructure.Data.Produto
{
    public class ProdutoConfiguration : EntityTypeConfiguration<ProdutoAgg.Produto>
    {
        public override void Map(EntityTypeBuilder<ProdutoAgg.Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(x => x.Codigo);
        }
    }
}