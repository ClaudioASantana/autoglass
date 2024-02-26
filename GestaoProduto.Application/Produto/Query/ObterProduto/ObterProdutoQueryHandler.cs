using AutoMapper;
using GestaoProduto.Domain.ProdutoAggregate;
using MediatR;

namespace GestaoProduto.Application.Produto.Query.ObterProduto
{
    public class ObterProdutoQueryHandler : IRequestHandler<ObterProdutoQuery, object>
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IMapper mapper;

        public ObterProdutoQueryHandler(IProdutoRepository produtoRepository, IMapper mapper)
        {
            this.produtoRepository = produtoRepository;
            this.mapper = mapper;
        }

        public async Task<object> Handle(ObterProdutoQuery request, CancellationToken cancellationToken)
        {
            var produto = produtoRepository.ObterPorCodigo(request.Codigo);
            var produtoViewModel = mapper.Map<ProdutoViewModel>(produto);

            return produtoViewModel;
        }
    }
}