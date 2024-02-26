using System;
using System.Linq;

namespace GestaoProduto.Domain.ProdutoAggregate
{
    public interface IProdutoRepository
    {
        Produto ObterPorCodigo(int codigo);
        Task<List<Produto>> ObterTodosProdutosAsync();
        void Registrar(Produto entity);
        void Atualizar(Produto entity);
        void Excluir(Produto entity);
    }
}
