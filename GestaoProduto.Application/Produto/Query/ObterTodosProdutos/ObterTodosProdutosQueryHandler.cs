using AutoMapper;
using GestaoProduto.Domain.ProdutoAggregate;
using MediatR;

namespace GestaoProduto.Application.Produto.Query.ObterTodosProdutos
{
    public class ObterTodosProdutosQueryHandler : 
        IRequestHandler<ObterTodosProdutosQuery, object>
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IMapper mapper;

        public ObterTodosProdutosQueryHandler(IProdutoRepository produtoRepository, IMapper mapper)
        {
            this.produtoRepository = produtoRepository;
            this.mapper = mapper;
        }

        public async Task<object> Handle(ObterTodosProdutosQuery request, CancellationToken cancellationToken)
        {
            var produto = await produtoRepository.ObterTodosProdutosAsync();
            var result = mapper.Map<List<ProdutoViewModel>>(produto);

            var resultPaginated = result.Skip(request.Skip == null? 0 : (int)request.Skip)
                .Take(request.Take == null && request.Take == 0 ? 100 : (int)request.Take);

            if (!string.IsNullOrWhiteSpace(request.DescricaoProduto))
                resultPaginated = resultPaginated.Where(p => p.Descricao.ToUpper().Contains(request.DescricaoProduto.ToUpper()));

            if (!string.IsNullOrWhiteSpace(request.DescricaoFornecedor))
                resultPaginated = resultPaginated.Where(p => p.DescricaoFornecedor.ToUpper().Contains(request.DescricaoFornecedor.ToUpper()));
            
            if (request.Situacao == Situacao.Ativo || request.Situacao == Situacao.Inativo)
            {
                int? situacao = (int)request.Situacao;
                resultPaginated = resultPaginated.Where(p => p.Situacao == request.Situacao);
            }

            if (request.DataFabricacao.HasValue)
                resultPaginated = resultPaginated.Where(p => p.DataFabricacao.Value.ToShortDateString() == request.DataFabricacao.Value.ToShortDateString());

            if (request.DataValidade.HasValue)
                resultPaginated = resultPaginated.Where(p => p.DataValidade.Value.ToShortDateString() == request.DataValidade.Value.ToShortDateString());

            if (request.CodigoFornecedor > 0)
                resultPaginated = resultPaginated.Where(p => p.CodigoFornecedor == request.CodigoFornecedor);

            if (!string.IsNullOrWhiteSpace(request.CnpjFornecedor))
                resultPaginated = resultPaginated.Where(p => p.CnpjFornecedor == request.CnpjFornecedor);


            return resultPaginated;
        }
    }
}