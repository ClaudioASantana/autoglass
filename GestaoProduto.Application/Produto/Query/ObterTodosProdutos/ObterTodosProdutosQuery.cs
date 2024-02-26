using GestaoProduto.Domain.ProdutoAggregate;
using MediatR;

namespace GestaoProduto.Application.Produto.Query.ObterTodosProdutos
{
    public class ObterTodosProdutosQuery : Query
    {
        public string? DescricaoProduto { get; set; }
        public Situacao? Situacao { get; set; }
        public string? DescricaoFornecedor { get; set; }
        public DateTime? DataFabricacao { get; set; }
        public DateTime? DataValidade { get; set; }
        public int? CodigoFornecedor { get; set; }
        public string? CnpjFornecedor { get; set; }
        public int? Skip { get; set; } = 0;
        public int? Take { get; set; } = 10;
    }

    public abstract class Query : IRequest<object>, IBaseRequest
    {
    }
}