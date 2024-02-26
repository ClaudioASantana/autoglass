using GestaoProduto.Domain.Core;
using GestaoProduto.Domain.ProdutoAggregate;
using GestaoProduto.Infrastructure.Data.UoW;
using MediatR;

namespace GestaoProduto.Application.Produto.Commands.AtualizarProduto
{
    public class AtualizarProdutoCommandHandler : CommandHandler,
        IRequestHandler<AtualizarProdutoCommand>
    {
        private readonly IProdutoRepository _produtoRepository;

        public AtualizarProdutoCommandHandler(
            IProdutoRepository produtoRepository,
            IUnitOfWork uow,
            IMediator mediator) : base(uow, mediator)
        {
            _produtoRepository = produtoRepository;
        }

        public Task Handle(AtualizarProdutoCommand request, CancellationToken cancellationToken)
        {
            if (request.Situacao != Situacao.Ativo) throw new BusinessRuleException("Produto deve estar ativo!");

            var produto = _produtoRepository.ObterPorCodigo(request.Codigo);

            produto.Descricao = request.Descricao;
            produto.DataFabricacao = request.DataFabricacao;
            produto.DataValidade = request.DataValidade;
            produto.CodigoFornecedor = request.CodigoFornecedor;
            produto.DescricaoFornecedor = request.DescricaoFornecedor;
            produto.CnpjFornecedor = request.CnpjFornecedor;
            produto.Situacao = request.Situacao;

            if (request.DataFabricacao != null && request.DataFabricacao >= request.DataValidade)
            {
                throw new BusinessRuleException("Data de fabricação inválida!");
            }

            _produtoRepository.Atualizar(produto);

            Commit();

            return Task.FromResult(true);
        }
    }
}