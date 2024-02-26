using Azure.Core;
using GestaoProduto.Domain.Core;
using GestaoProduto.Domain.ProdutoAggregate;
using Microsoft.EntityFrameworkCore;
using ProdutoAgg = GestaoProduto.Domain.ProdutoAggregate;

namespace GestaoProduto.Infrastructure.Data.Produto
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly GestaoProdutoContext context;

        public ProdutoRepository(GestaoProdutoContext context)
        {
            this.context = context;
        }

        public void Atualizar(ProdutoAgg.Produto entity)
        {
            if (entity.DataFabricacao != null && entity.DataFabricacao >= entity.DataValidade)
                throw new BusinessRuleException("Data de fabricação inválida!");

            if (entity.Situacao == Situacao.Inativo)
                throw new BusinessRuleException("Produto deve estar ativo!");

            context.Set<ProdutoAgg.Produto>().Update(entity);
        }

        public void Excluir(ProdutoAgg.Produto entity)
        {
            entity.Inativar();
            context.Set<ProdutoAgg.Produto>().Update(entity);
        }

        public ProdutoAgg.Produto ObterPorCodigo(int codigo)
        {
            return context.Set<ProdutoAgg.Produto>().FirstOrDefault(c => c.Codigo == codigo);
        }

        public async Task<List<ProdutoAgg.Produto>> ObterTodosProdutosAsync()
        {
            return await context.Set<ProdutoAgg.Produto>().ToListAsync();
        }

        public void Registrar(ProdutoAgg.Produto entity)
        {
            context.Set<ProdutoAgg.Produto>().Add(entity);
        }
    }
}