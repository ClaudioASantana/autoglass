using GestaoProduto.Domain.Core;
using GestaoProduto.Domain.ProdutoAggregate;
using GestaoProduto.Infrastructure.Data.Produto;

using ProdutoAgg = GestaoProduto.Domain.ProdutoAggregate;

namespace GestaoProduto.Test.Produto
{
    public class ProdutoAggregate_AtualizarPrecoDeve
    {
        [Fact]
        public void AtivarSituacaoProduto()
        {
            //Dado
            var produto = new ProdutoAgg.Produto("Produto0001", DateTime.Now.AddDays(-1), DateTime.Now, 3, "Fornecedor de XUnit Teste", "0123456");

            //Quando
            produto.Ativar();

            //Então
            Assert.Equal(Situacao.Ativo, produto.Situacao);
        }

        [Fact]
        public void InativarSituacaoProduto()
        {
            //Dado
            var produto = new ProdutoAgg.Produto("Produto0001", DateTime.Now.AddDays(-1), DateTime.Now, 3, "Fornecedor de XUnit Teste", "0123456");

            //Quando
            produto.Inativar();

            //Então
            Assert.Equal(Situacao.Inativo, produto.Situacao);
        }

        [Fact]
        public void NotificarErroQuandoDataFabricacaoInvalida()
        {
            //Dado
            var produto = new ProdutoAgg.Produto("Produto0001", DateTime.Now.AddDays(1), DateTime.Now, 3, "Fornecedor de XUnit Teste", "0123456");
            IProdutoRepository produtoRepository = new ProdutoRepository(new Infrastructure.Data.GestaoProdutoContext());

            //Quando
            var ex = Assert.Throws<BusinessRuleException>(() => produtoRepository.Atualizar(produto));

            //Então
            Assert.Equal("Data de fabricação inválida!", ex.Message);
        }

        [Fact]
        public void NotificarErroQuandoProdutoEstaCancelado()
        {
            //Dado
            var produto = new ProdutoAgg.Produto("Produto0001", DateTime.Now.AddDays(-1), DateTime.Now, 3, "Fornecedor de XUnit Teste", "0123456");
            IProdutoRepository produtoRepository = new ProdutoRepository(new Infrastructure.Data.GestaoProdutoContext());

            produto.Inativar();

            //Quando
            var ex = Assert.Throws<BusinessRuleException>(() => produtoRepository.Atualizar(produto));

            //Então
            Assert.Equal("Produto deve estar ativo!", ex.Message);
        }
    }
}